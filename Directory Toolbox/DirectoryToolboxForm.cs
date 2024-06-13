using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Directory_Toolbox {

    public partial class DirectoryToolboxForm : Form {
        private readonly int leftPanelSize = 250;

        private readonly int rightPanelSize = 250;

        private List<Script> scripts;

        public DirectoryToolboxForm( )
            => InitializeComponent( );

        private int centerPanelSize => Width - leftPanelSize - rightPanelSize;

        /// <summary>
        /// Flips visiblity of the mask text box when CheckMask is checked or unchecked.
        /// </summary>
        /// <param name="sender"> Unused </param>
        /// <param name="e">      Unused </param>
        private void changeCheckMask( object sender, EventArgs e )
            => TextMask.Visible = CheckMask.Checked;

        /// <summary>
        /// Deletes a script
        /// </summary>
        /// <param name="sender"> The button that was clicked </param>
        /// <param name="e">      Unused </param>
        private void clickDelete( object sender, EventArgs e ) {
            Script? s = getScriptFromControl(sender);
            if ( s is not null ) {
                s.Delete( );
                scripts.Remove( s );
            }
            setScriptsPanel( );
        }

        /// <summary>
        /// Loads a script into the editor
        /// </summary>
        /// <param name="sender"> The button clicked </param>
        /// <param name="e">      Unused </param>
        private void clickEdit( object sender, EventArgs e ) {
            Script? s = getScriptFromControl(sender);
            if ( s is not null ) {
                TextEditor.Text = s.Content;
                textBox1.Text = s.Name;
            }
        }

        /// <summary>
        /// Runs the script
        /// </summary>
        /// <param name="sender"> The button clicked </param>
        /// <param name="e">      Unused </param>
        private void clickRun( object sender, EventArgs e ) {
            Script? s = getScriptFromControl(sender);
            if ( s is null )
                return;
            if ( s.Name != textBox1.Text ) {
                TextEditor.Text = s.Content;
                textBox1.Text = s.Name;
            }
            clickSave( sender, e );
            ScriptExecutionResult res = ScriptExecutor.RunScript( s, new( CheckRecurse.Checked, CheckMask.Checked ? TextMask.Text : "*.*"  , TextPath.Text ));

            if ( res.Error == null ) {
                label2.Text = $"{res.FilesProcessed} files processed.";
                label3.Text = $"{res.DirectoriesProcessed} dirs processed.";
                label4.Text = res.Status;
            }
            else {
                TextEditor.Text = res.Error.Message;
            }
        }

        /// <summary>
        /// Saves the currently loaded script
        /// </summary>
        /// <param name="sender"> Unused </param>
        /// <param name="e">      Unused </param>
        private void clickSave( object sender, EventArgs e ) {
            Script s = scripts.FirstOrDefault(x => x.Name == textBox1.Text);
            if ( s is null ) {
                try {
                    s = Script.New( textBox1.Text, TextEditor.Text );
                    goto written;
                }
                catch ( IOException ) {
                    textBox1.Text = "Could not write file.";
                    return;
                }
            }

            s.Content = TextEditor.Text;
            s.Save( );

        written:

            if ( !scripts.Contains( s ) )
                scripts.Add( s );

            TextEditor.Focus( );

            setScriptsPanel( );
        }

        /// <summary>
        /// Sets the folder path from a directory picker dialog
        /// </summary>
        /// <param name="sender"> Unused </param>
        /// <param name="e">      Unused </param>
        private void clickSeek( object sender, EventArgs e ) {
            if ( folderBrowserDialog1.ShowDialog( ) == DialogResult.OK ) {
                TextPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// Gets a script from an object representing a control
        /// </summary>
        /// <param name="o"> The control to read the tag of </param>
        /// <returns> A script, if one existed in the list. Null otherwise. </returns>
        private Script? getScriptFromControl( object o )
                    => scripts.FirstOrDefault( x => x.Name == (string) ( (Control) o ).Tag );

        /// <summary>
        /// Sets up the form
        /// </summary>
        /// <param name="sender"> Unused </param>
        /// <param name="e">      Unused </param>
        private void loadForm( object sender, EventArgs e ) {
            string BasePath = Script.BasePath;

            if ( !Directory.Exists( BasePath ) ) {
                Directory.CreateDirectory( BasePath + "Example Script/" );
                BasePath += "Example Script/";
                File.WriteAllText( BasePath + "script.cs", TextEditor.Text );
            }

            scripts = Script.ReadAll( );
            setScriptsPanel( );
            TextPath.Text = Path.GetDirectoryName( Assembly.GetExecutingAssembly( ).Location );
            //:) cheating
            Size = Size + new Size( 1, 1 );
        }

        /// <summary>
        /// Sets up the scripts panel
        /// </summary>
        private void setScriptsPanel( ) {
            int ThisScript = 0;
            //Clear the script list
            PanelScriptList.Controls.Clear( );

            int Width = leftPanelSize;

            foreach ( Script s in scripts ) {
                //Create script panel
                Panel tsp = new( ) {
                    Height = 40,
                    Width = leftPanelSize,
                    Location = new Point( 2, 40 * ThisScript++ )
                };
                PanelScriptList.Controls.Add( tsp );

                //Create name label
                Label NameLabel = new( ) {
                    Font = new Font( "Segoe UI", 12f ),
                    Text = s.Name,
                    Width = tsp.Width,
                    ForeColor = Color.White
                };
                tsp.Controls.Add( NameLabel );

                //Create edit button
                Button EditButton = new( ) {
                    Text = "📝",
                    Size = new Size( (int) ( tsp.Width * 0.3f ), 20 ),
                    Location = new Point( 0, 20 ),
                    FlatStyle = FlatStyle.Standard,
                    BackColor = Color.FromKnownColor( KnownColor.Control ),
                    Tag = s.Name
                };
                EditButton.Click += clickEdit;
                tsp.Controls.Add( EditButton );
                EditButton.BringToFront( );

                //Create run button
                Button RunButton = new( ) {
                    Text = "▶️",
                    Size = new Size( (int) ( tsp.Width * 0.3f ), 20 ),
                    Location = new Point( EditButton.Size.Width + 10, 20 ),
                    FlatStyle = FlatStyle.Standard,
                    BackColor = Color.FromKnownColor( KnownColor.Control ),
                    Tag = s.Name
                };
                RunButton.Click += clickRun;
                tsp.Controls.Add( RunButton );
                RunButton.BringToFront( );

                //Create delete button
                Button DeleteButton = new( ) {
                    Text = "🗑️",
                    Size = new Size( (int) ( tsp.Width * 0.3f ), 20 ),
                    Location = new Point( ( 2 * EditButton.Size.Width ) + 20, 20 ),
                    FlatStyle = FlatStyle.Standard,
                    BackColor = Color.FromKnownColor( KnownColor.Control ),
                    Tag = s.Name
                };
                DeleteButton.Click += clickDelete;
                tsp.Controls.Add( DeleteButton );
                DeleteButton.BringToFront( );
            }
        }

        /// <summary>
        /// Recalculates the size and position of form elements
        /// </summary>
        /// <param name="sender"> Unused </param>
        /// <param name="e">      Unused </param>
        private void sizeForm( object sender, EventArgs e ) {
            int largePanelHeight = Height - 30;
            int smallPanelHeight = Height - 60;

            //Move the panels and sizes
            PanelScripts.Location = new Point( );
            PanelScripts.Size = new Size( leftPanelSize, largePanelHeight );

            PanelEditor.Location = new Point( leftPanelSize, 0 );
            PanelEditor.Size = new Size( centerPanelSize, largePanelHeight );

            PanelOptions.Location = new Point( Width - rightPanelSize, 0 );
            PanelOptions.Size = new Size( rightPanelSize, largePanelHeight );

            PanelOptionList.Size = new Size( rightPanelSize, smallPanelHeight );

            //Make the height of the panels the full height
            TextEditor.Height = smallPanelHeight;
            PanelScriptList.Height = smallPanelHeight;

            //Set the widths and locations of certain components
            TextPath.Width = rightPanelSize - 60;
            TextMask.Width = 50;
            textBox1.Width = centerPanelSize - 40;
            Point L = textBox1.Location;
            L.Y = Height - 60;
            textBox1.Location = L;
            L = label1.Location;
            L.Y = Height - 57;
            label1.Location = L;
            Point l = ButtonSeekDir.Location;
            l.X = TextPath.Location.X + TextPath.Width + 5;
            ButtonSeekDir.Location = l;
            setScriptsPanel( );
        }

        /// <summary>
        /// Converts tabs to spaces
        /// </summary>
        /// <param name="sender"> Unused </param>
        /// <param name="e">      Unused </param>
        private void writeTextEditor( object sender, EventArgs e ) {
            if ( TextEditor.Text.Contains( "\t" ) ) {
                int pos = TextEditor.SelectionStart;
                TextEditor.Text = TextEditor.Text.Replace( "\t", "    " );
                pos += 3;
                TextEditor.SelectionStart = pos;
                TextEditor.Focus( );
            }
        }
    }
}

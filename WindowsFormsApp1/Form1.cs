using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(cmd_window_Keypress);
            KeyDown += new KeyEventHandler(cmd_enter);
            KeyDown += new KeyEventHandler(Fkeys);

            timer1.Tick += new EventHandler(timer1_Tick);
            //timer1.Interval = 1000; //1 second
            timer1.Interval = 500; //current timer
            timer1.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_DirPath.Text = regi_key();
            txt_dirPathPhone.Text = Phone_regi_key();
            Panel_Fill();
            Panel_Phone_Setup();
            get_reminder();
            cmd_window();
            GetBG();
            //newform();
        }
        private void btn_Reload_Click(object sender, EventArgs e)
        {
            GetBG();

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MyNotes\DirectoryPath");
            if (key.GetValue("") != null)
            {
                key.DeleteValue("DirectoryPath");
            }
            //storing the values  
            key.SetValue("DirectoryPath", txt_DirPath.Text);
            key.Close();

            RegistryKey Phonekey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MyNotes\PhonePath");
            if (Phonekey.GetValue("") != null)
            {
                Phonekey.DeleteValue("PhonePath");
            }
            //storing the values  
            Phonekey.SetValue("PhonePath", txt_dirPathPhone.Text);
            Phonekey.Close();

            Panel_Fill();
            Panel_Phone_Setup();
            get_reminder();
        }

        private void btn_Setup_Click(object sender, EventArgs e)
        {
            Process.Start(regi_key());
        }

        private void Panel_Fill()
        {
            pan_main.Controls.Clear();
            try
            {
                var filepath = System.IO.Directory.GetFiles(regi_key()).ToList();
                foreach (string files in filepath)
                {
                    if (files != regi_key() + "\\Editor.txt") //Hides the Editor
                    {
                        Panel _panels = new Panel();
                        _panels.Width = pan_main.Width - 18;
                        _panels.Height = 25;
                        _panels.Name = files.ToString();
                        _panels.Top = _panels.Height * (pan_main.Controls.Count);

                        Button btn_Del_file = new Button();
                        btn_Del_file.FlatStyle = FlatStyle.Flat;
                        btn_Del_file.FlatAppearance.BorderColor = Color.Green;
                        btn_Del_file.Name = _panels.Name;
                        btn_Del_file.Width = _panels.Width / 8;
                        btn_Del_file.Height = _panels.Height;
                        btn_Del_file.BackgroundImageLayout = ImageLayout.Stretch;
                        btn_Del_file.BackgroundImage = Image.FromFile(@"C:\Users\williamyu\Pictures\X_pic.jpg");
                        btn_Del_file.Cursor = Cursors.Hand;
                        btn_Del_file.Click += new System.EventHandler(this.btn_Del_file_Click);

                        Button btn_file = new Button();
                        btn_file.BackColor = Color.Yellow;
                        btn_file.FlatStyle = FlatStyle.Flat;
                        btn_file.FlatAppearance.BorderColor = Color.Green;
                        btn_file.Name = _panels.Name;
                        btn_file.Width = _panels.Width - 75;
                        btn_file.Height = _panels.Height;
                        btn_file.Location = new Point(btn_Del_file.Width);
                        btn_file.Text = _panels.Name.Replace(regi_key() + "\\", "");
                        btn_file.Cursor = Cursors.Hand;
                        btn_file.Click += new System.EventHandler(this.btn_Click);

                        Button btn_open = new Button();
                        btn_open.BackColor = Color.Yellow;
                        btn_open.FlatStyle = FlatStyle.Flat;
                        btn_open.FlatAppearance.BorderColor = Color.Green;
                        btn_open.Name = _panels.Name;
                        btn_open.Width = _panels.Width - (btn_file.Width - btn_Del_file.Width);
                        btn_open.Height = _panels.Height;
                        btn_open.Location = new Point(btn_file.Width);
                        btn_open.Text = "Open";
                        btn_open.TextAlign = ContentAlignment.MiddleCenter;
                        btn_open.Cursor = Cursors.Hand;
                        btn_open.Click += new System.EventHandler(this.btn_open_click);

                        _panels.Controls.Add(btn_Del_file);
                        _panels.Controls.Add(btn_file);
                        _panels.Controls.Add(btn_open);
                        pan_main.Controls.Add(_panels);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Panel_Fill()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                Button _btn = (Button)sender;
                if(_btn.Name == "btn_Reminder")
                {
                    _btn.Name = regi_key() + "\\Reminder.txt";
                }
                string[] readlines = System.IO.File.ReadAllLines(_btn.Name);
                txt_ShipMode.Text = string.Empty;
                Label_FileName.Text = _btn.Name.Replace(regi_key() + "\\", "");

                int cntlines = 0;
                int currentlines = 1;

                foreach (string lines in readlines)
                {
                    cntlines++;
                }

                foreach (string lines in readlines)
                {
                    if (currentlines == cntlines)
                    {
                        txt_ShipMode.AppendText(lines);
                    }
                    else
                    {
                        txt_ShipMode.AppendText(lines + "\r\n");
                        currentlines++;
                    }
                }
                txt_ShipMode.SelectionStart = 0;
                txt_ShipMode.ScrollToCaret();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "btn_Click(" + sender.ToString() + "," + e.ToString() + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_open_click(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;
            Process.Start(_btn.Name);
        }

        private void btn_Del_file_Click(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;
            var filepath = System.IO.Directory.GetFiles(regi_key()).ToList();
            foreach(string file in filepath)
            {
                if (_btn.Name == file)
                {
                    var msg = MessageBox.Show("Delete: " + _btn.Name.Replace(regi_key() + "\\",""), "Delete file?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if(msg == DialogResult.OK)
                    {
                        System.IO.File.Delete(_btn.Name);
                        btn_Reload_Click(sender, e);
                    }
                    break;
                }
            }
        }
        private void Panel_Phone_Setup()
        {
            try
            {
                Pan_Phone_Setup.Controls.Clear();
                var filepath = System.IO.Directory.GetFiles(Phone_regi_key()).ToList();
                foreach (string files in filepath)
                {
                    Panel _panels = new Panel();
                    _panels.Width = Pan_Phone_Setup.Width - 18;
                    _panels.Height = 25;
                    _panels.Name = files.ToString();
                    _panels.Top = _panels.Height * (Pan_Phone_Setup.Controls.Count);

                    Button btn_Del_file = new Button();
                    btn_Del_file.FlatStyle = FlatStyle.Flat;
                    btn_Del_file.FlatAppearance.BorderColor = Color.Green;
                    btn_Del_file.Name = _panels.Name;
                    btn_Del_file.Width = _panels.Width / 10;
                    btn_Del_file.Height = _panels.Height;
                    btn_Del_file.BackgroundImageLayout = ImageLayout.Stretch;
                    btn_Del_file.BackgroundImage = Image.FromFile(@"C:\Users\williamyu\Pictures\X_pic.jpg");
                    btn_Del_file.Cursor = Cursors.Hand;
                    btn_Del_file.Click += new System.EventHandler(this.btn_Del_file_Phone_Click);

                    Button btn_file = new Button();
                    btn_file.BackColor = Color.Yellow;
                    btn_file.FlatStyle = FlatStyle.Flat;
                    btn_file.FlatAppearance.BorderColor = Color.Green;
                    btn_file.Name = _panels.Name;
                    btn_file.Width = _panels.Width - 120;
                    btn_file.Height = _panels.Height;
                    btn_file.Location = new Point(btn_Del_file.Width);
                    btn_file.Text = _panels.Name.Replace(Phone_regi_key() + "\\", "");
                    btn_file.Cursor = Cursors.Hand;
                    btn_file.Click += new System.EventHandler(this.btn_Phone_Click);

                    Button btn_open = new Button();
                    btn_open.BackColor = Color.Yellow;
                    btn_open.FlatStyle = FlatStyle.Flat;
                    btn_open.FlatAppearance.BorderColor = Color.Green;
                    btn_open.Name = _panels.Name;
                    btn_open.Width = _panels.Width - (btn_file.Width - btn_Del_file.Width);
                    btn_open.Height = _panels.Height;
                    btn_open.Location = new Point(btn_file.Width);
                    btn_open.Text = "Open";
                    btn_open.TextAlign = ContentAlignment.MiddleCenter;
                    btn_open.Cursor = Cursors.Hand;
                    btn_open.Click += new System.EventHandler(this.btn_Phone_open_click);

                    _panels.Controls.Add(btn_Del_file);
                    _panels.Controls.Add(btn_file);
                    _panels.Controls.Add(btn_open);
                    Pan_Phone_Setup.Controls.Add(_panels);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Panel_Phone_Setup()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Phone_Click(object sender, EventArgs e)
        {
            try
            {
                Button _btn = (Button)sender;
                string[] readlines = System.IO.File.ReadAllLines(_btn.Name);
                int cntlines = 0;
                int currentlines = 1;
                foreach (string lines in readlines)
                {
                    cntlines++;
                }
                txt_log.Text = string.Empty;
                foreach (string lines in readlines)
                {
                    if (currentlines == cntlines)
                    {
                        txt_log.AppendText(lines);
                    }
                    else
                    {              
                        txt_log.AppendText(lines + "\r\n");
                        currentlines++;
                    }
                }
                Label_phoneName.Text = _btn.Name.Replace(Phone_regi_key() + "\\", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btn_Phone_Click(" + sender.ToString() + "," + e.ToString() + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Phone_open_click(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;
            Process.Start(_btn.Name);
        }

        private void btn_Del_file_Phone_Click(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;
            var filepath = System.IO.Directory.GetFiles(Phone_regi_key()).ToList();
            foreach (string file in filepath)
            {
                if (_btn.Name == file)
                {
                    var msg = MessageBox.Show("Delete: " + _btn.Name.Replace(Phone_regi_key() + "\\", ""), "Delete file?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (msg == DialogResult.OK)
                    {
                        System.IO.File.Delete(_btn.Name);
                        btn_Reload_Click(sender, e);
                    }
                    break;
                }
            }
        }
        private void get_reminder()
        {
            string filepath = regi_key();
            try
            {
                var files = System.IO.Directory.GetFiles(filepath);
                foreach (string file in files)
                {
                    if (file.Contains("Reminder"))
                    {
                        btn_Reminder.Visible = true;
                        break;
                    }
                    else
                    {
                        btn_Reminder.Visible = false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "get_reminder()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string regi_key()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MyNotes\DirectoryPath");                
                    return key.GetValue("DirectoryPath").ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "regi_key()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private string Phone_regi_key()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MyNotes\PhonePath");
                return key.GetValue("PhonePath").ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Phone_regi_key()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        TextBox cmd_history = new TextBox();
        TextBox cmd_line = new TextBox();
        private void cmd_window()
        {         
            cmd_history.Visible = false;
            cmd_history.Multiline = true;
            cmd_history.ScrollBars = ScrollBars.Vertical;
            cmd_history.Width = this.Width;
            cmd_history.Height = this.Height / 3;
            cmd_history.Dock = DockStyle.Top;
            cmd_history.BackColor = Color.Black;
            cmd_history.ForeColor = Color.White;
            cmd_history.Text = "Type !help for list of commands" + "\r\n";
            cmd_history.BringToFront();
            this.Controls.Add(cmd_history);
          
            cmd_line.Visible = false;
            cmd_line.Width = cmd_history.Width;
            cmd_line.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            cmd_line.Height = 100;
            cmd_line.BackColor = Color.Black;
            cmd_line.ForeColor = Color.White;
            cmd_line.Location = new Point(cmd_history.Location.X, cmd_history.Height);
            cmd_line.BringToFront();
            this.Controls.Add(cmd_line);
        }
        private void cmd_window_Keypress(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.F1 && cmd_history.Visible == false)
            {
                cmd_history.Visible = true;
                cmd_line.Visible = true;
                cmd_line.Focus();
                pan_main.Visible = false;
                txt_ShipMode.Visible = false;
                txt_DirPath.Visible = false;
                Label_FileName.Visible = false;
                btn_Reload.Visible = false;
                btn_Setup.Visible = false;
                btn_Reminder.Location = new Point(cmd_history.Location.X, cmd_history.Height + 25);
            }
            else if (e.KeyCode == Keys.F1 && cmd_history.Visible == true)
            {
                cmd_history.Visible = false;
                cmd_line.Visible = false;
                pan_main.Visible = true;
                txt_ShipMode.Visible = true;
                txt_DirPath.Visible = true;
                Label_FileName.Visible = true;
                btn_Reload.Visible = true;
                btn_Setup.Visible = true;
                //make phone things visible
                txt_dirPathPhone.Visible = true;
                Label_phoneName.Visible = true;
                Pan_Phone_Setup.Visible = true;
                txt_log.Visible = true;
                btn_Reminder.Location = new Point(cmd_history.Location.X, (btn_Reminder.Location.Y - cmd_history.Height) - 25);
            }
        }
        private void cmd_enter(object sender, KeyEventArgs e)
        {
            int cmd_exist_cnt = 0;
            if (e.KeyCode == Keys.Enter && cmd_history.Visible == true)
            {
                switch(cmd_line.Text)
                {
                    case "!reload":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MyNotes\DirectoryPath");
                            //storing the values  
                            key.SetValue("DirectoryPath", txt_DirPath.Text);
                            key.Close();

                            RegistryKey Phonekey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MyNotes\PhonePath");
                            //storing the values  
                            Phonekey.SetValue("PhonePath", txt_dirPathPhone.Text);
                            Phonekey.Close();

                            Panel_Fill();
                            Panel_Phone_Setup();
                            get_reminder();                    
                            break;
                        }
                    case "!msg":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            MessageBox.Show("Hi", "Hey it's working!");
                            break;
                        }
                    case "!help":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            cmd_history.AppendText("***Accepted commands***" + "\r\n");
                            foreach (KeyValuePair<string,string> cmd in CMD_List())
                            {
                                cmd_history.AppendText(cmd.Key + " -- " + cmd.Value + "\r\n");
                            }
                            cmd_history.AppendText("*************" + "\r\n");
                            break;
                        }
                    case "!open notepad":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            Process.Start("C:\\windows\\system32\\notepad.exe");
                            break;
                        }
                    case "!open notepad++":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            Process.Start("C:\\Program Files (x86)\\Notepad++\\notepad++.exe");
                            break;
                        }
                    case "!open cmd":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            //Process.Start("C:\\windows\\system32\\cmd.exe");
                            Process.Start("C:\\Users\\williamyu\\Desktop\\cmd - Shortcut");
                            //Process cmd = new Process();
                            //cmd.StartInfo.FileName = "cmd.exe";
                            //cmd.StartInfo.UseShellExecute = false;
                            //cmd.StartInfo.RedirectStandardOutput = true;
                            //cmd.StartInfo.RedirectStandardInput = true;
                            //cmd.Start();
                            //cmd.StandardInput.WriteLine(@"C:\\Users\\williamyu\\Desktop\\cmd - Shortcut");
                            //cmd.StandardInput.WriteLine("cd C:\\Users\\williamyu\\Desktop\\");
                            break;
                        }
                    case "!open teraterm":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            Process.Start("C:\\Program Files (x86)\\teraterm\\ttermpro.exe");
                            break;
                        }
                    case "!open textwindow":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            txt_Editor();
                            break;
                        }
                    case "!list bg":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            string[] path = System.IO.Directory.GetFiles("C:\\Users\\williamyu\\Pictures\\MyNotes_SetBG");
                            foreach(string files in path)
                            {
                                cmd_history.AppendText(files.Replace("C:\\Users\\williamyu\\Pictures\\MyNotes_SetBG\\", "") + "\r\n");
                            }
                            break;
                        }
                    case "!hide":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            foreach (Control crls in this.Controls)
                            {
                                crls.Hide();
                            }
                            break;
                        }
                    case "!play bg":
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            //ToDo code
                            break;
                        }
                    default:
                        {
                            cmd_exist_cnt++;
                            break;
                        }
                }
                if (cmd_line.Text.Contains("!set image "))
                    {
                        string replacecmd = cmd_line.Text.Replace("!set image ", "");
                        try
                        {
                            cmd_history.AppendText(cmd_line.Text + "\r\n");
                            OpenImg(replacecmd);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "cmd_enter(" + sender.ToString() + "," + e.ToString() + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);                          
                        }
                        finally
                        {
                            cmd_exist_cnt = cmd_exist_cnt - 1;
                        }
                    }
                if (cmd_line.Text.Contains("!set bg "))
                {
                    string replacecmd = cmd_line.Text.Replace("!set bg ", "");
                    try
                    {
                        cmd_history.AppendText(cmd_line.Text + "\r\n");
                        setbg(replacecmd);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "cmd_enter(" + sender.ToString() + "," + e.ToString() + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cmd_exist_cnt = cmd_exist_cnt - 1;
                    }
                }
                if (cmd_exist_cnt == 1)
                    {
                        cmd_history.AppendText(cmd_line.Text + "(Command does not exists)" + "\r\n");
                    }
                cmd_line.Text = string.Empty;
            }
        }
        private Dictionary<string,string> CMD_List()
        {
            var _CMDList = new Dictionary<string, string>();
            _CMDList.Add("!msg", "Open up a message box");
            _CMDList.Add("!reload", "Reload this application");
            _CMDList.Add("!open notepad", "Open Notepad");
            _CMDList.Add("!open notepad++", "Open Notepad");
            _CMDList.Add("!open teraterm","Open TeraTerm");
            _CMDList.Add("!open cmd", "Open Command Prompt(WIP)");
            _CMDList.Add("!open textwindow", @"Open Editor.txt in current directory");
            _CMDList.Add("!list bg", "List bg in path");
            _CMDList.Add("!set image ", "Set Image <filename> *Exclude extension*");
            _CMDList.Add("!set bg", "Set bg <filename.png>");
            _CMDList.Add("!hide", "Hide all controls, Send in !reload to show all controls");
            _CMDList.Add("!play bg", "start a slideshow bg.(WIP)");
            return _CMDList;
        }
        Form newF = new Form();
        TextBox txt_win = new TextBox();
        private void txt_Editor()
        {
            newF.StartPosition = FormStartPosition.CenterScreen;
            newF.Text = "NotePad";

            txt_win.Multiline = true;
            txt_win.Text = string.Empty; //Must clear textbox.
            txt_win.Width = 720;
            txt_win.Height = 480;
            txt_win.Dock = DockStyle.Fill;
            txt_win.ScrollBars = ScrollBars.Both;
            txt_win.BackColor = Color.Black;
            txt_win.ForeColor = Color.White;

            string[] ReadEditor = System.IO.File.ReadAllLines(regi_key() + "\\Editor.txt");

            int cntlines = 0;
            int currentlines = 1;

            foreach(string lines in ReadEditor)
            {
                cntlines++;
            }

            foreach (string line in ReadEditor)
            {
                if (currentlines == cntlines)
                {
                    txt_win.AppendText(line);
                }
                else
                {
                    txt_win.AppendText(line + "\r\n");
                    currentlines++;
                }
            }

            newF.Width = txt_win.Width;
            newF.Height = txt_win.Height;

            newF.FormClosing += new FormClosingEventHandler(FormEditorClosing);
            newF.Controls.Add(txt_win);
            newF.Show();
        }

        private void FormEditorClosing(object sender, FormClosingEventArgs e)
        {
            if(System.IO.File.Exists(@"C:\Users\williamyu\Desktop\Scuff_Database\Editor.txt"))
            {
                System.IO.File.WriteAllLines(@"C:\Users\williamyu\Desktop\Scuff_Database\Editor.txt", txt_win.Text.Split('\b'));
            }         
            newF.Hide();
            e.Cancel = true;
        }

        private void Fkeys(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txt_Editor();
            }
            else if(e.KeyCode == Keys.F3)
            {
                foreach (Control crls in this.Controls)
                {
                    crls.Hide();
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                foreach (Control crls in this.Controls)
                {
                    //cmd_history.AppendText(crls.Name.ToString() + "\r\n");
                    if (crls.Name == btn_Reminder.Name)
                    {
                        crls.Hide();
                    }
                    else if (crls.Name == cmd_history.Name)
                    {
                        crls.Hide();
                    }
                    else if(crls.Name == cmd_line.Name)
                    {
                        crls.Hide();
                    }
                    else
                    {
                        crls.Show();
                    }
                }
            }
        }

        Form formImage = new Form();
        PictureBox pb = new PictureBox();
        private void formImage_OnExit(object sender, FormClosingEventArgs e)
        {
            formImage.Hide();
            e.Cancel = true;
        }
        public void newform(string fromfile)
        {          
            //formImage.Location = new Point(this.Location.X, this.Location.Y);
            pb.Image = Image.FromFile(fromfile);
            pb.SizeMode = PictureBoxSizeMode.AutoSize;

            formImage.Width = pb.Width;
            formImage.Height = pb.Height;

            formImage.Controls.Add(pb);
            formImage.Show();
        }
        private void OpenImg(string fromfile)
        {
            formImage.FormClosing += new FormClosingEventHandler(formImage_OnExit);
            newform("C:\\Users\\williamyu\\Pictures\\MyNotes_Photo\\" + fromfile + ".png");
        }
        private void setbg(string fromfile)
        {
            try
            {
                RegistryKey BGkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MyNotes\BackGroundPath");
                BGkey.SetValue("BackGroundPath", @"C:\Users\williamyu\Pictures\MyNotes_SetBG\" + fromfile);
                this.BackgroundImage = Image.FromFile(BGkey.GetValue("BackGroundPath").ToString());
                BGkey.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "setbg " + fromfile, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetBG()
        {
            try
            {
                RegistryKey BGkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MyNotes\BackGroundPath");
                this.BackgroundImage = Image.FromFile(BGkey.GetValue("BackGroundPath").ToString());
                BGkey.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "GetBG()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PlayBgTimer()
        {
            List<string> BGlist = new List<string>();
            string[] BGpath = System.IO.Directory.GetFiles(@"C:\Users\williamyu\Pictures\MyNotes_SetBG\");        
            foreach(string path in BGpath)
            {
                BGlist.Add(path);
            }

            timer1.Start();

            

            timer1.Stop();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txt_log.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (btn_Reminder.BackColor == Color.Yellow)
            {
                btn_Reminder.BackColor = Color.Green;
            }
            else if (btn_Reminder.BackColor == Color.Green)
            {
                btn_Reminder.BackColor = Color.Yellow;
            }
        }
    }
}

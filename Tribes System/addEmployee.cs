﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tribes_System
{
    public partial class addEmployee : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=tribes_system;user=root;password=root");
        MySqlCommand cmd;

        private bool drag = false;
        private Point startPoint = new Point(0, 0);

        string stat = "";

        public addEmployee()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addEvent_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void startTime_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            nameBox.Clear();
        }

        private void locBox_Click(object sender, EventArgs e)
        {
            addressBox.Clear();
        }

        private void conClientBox_Click(object sender, EventArgs e)
        {
            numBox.Clear();
        }

        private void addButt_Click(object sender, EventArgs e)
        {
            if (nameBox.Text != "" && addressBox.Text != "" && numBox.Text != "" && stat != "")
            {
                if (nameBox.Text != "Name of Employee" && addressBox.Text != "Address of Employee" && numBox.Text != "Contact Number of Employee")
                {
                    DialogResult dg = MessageBox.Show("Are you sure?","Alert!",MessageBoxButtons.YesNo);
                    if(dg == DialogResult.Yes)
                    {
                        string insertQuery = "INSERT INTO employee(emp_name, emp_address, emp_contact, emp_status) VALUES ('" + nameBox.Text + "','" + addressBox.Text + "','" + numBox.Text + "','" + stat + "')";
                        executeMyQuery(insertQuery);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Dispose();
                    }
                    
                }
                else
                {
                    alertLabel.Visible = true;
                }
            }
            else
            {
                alertLabel.Visible = true;
            }
            
            
        }

        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public void executeMyQuery(string query)
        {
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, con);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    //MessageBox.Show("Executed");
                    MessageBox.Show("Employee Added Successfully");
                }

                else
                {
                    MessageBox.Show("Not Executed");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        private void title_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X,
                                     p2.Y - this.startPoint.Y);
                this.Location = p3;
            }
        }

        private void title_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        private void title_MouseDown(object sender, MouseEventArgs e)
        {
            this.startPoint = e.Location;
            this.drag = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.stat = "call";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                this.stat = "full";
            }
        }
    }
}

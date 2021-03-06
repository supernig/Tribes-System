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
    public partial class editEvent : Form
    {
        eventSched form = new eventSched();
        MySqlConnection con = new MySqlConnection("server=localhost;database=store;user=root;password=root");
        MySqlCommand cmd;

        private bool drag = false;
        private Point startPoint = new Point(0, 0);

        public editEvent(eventSched form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editEvent_MouseMove(object sender, MouseEventArgs e)
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

        private void editEvent_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        private void editEvent_MouseDown(object sender, MouseEventArgs e)
        {
            this.startPoint = e.Location;
            this.drag = true;
        }

        public string nameBox
        {
            get { return eventBox.Text; }
            set { eventBox.Text = value; }
        }
        
        public string locateBox
        {
            get { return locBox.Text; }
            set { locBox.Text = value; }
        }

        public string amBox
        {
            get { return amountBox.Text; }
            set { amountBox.Text = value; }
        }

        public string passNoteBox
        {
            get { return notesBox.Text; }
            set { notesBox.Text = value; }
        }

        public string clientNameBox
        {
            get { return nameClientBox.Text; }
            set { nameClientBox.Text = value; }
        }

        public string numBox
        {
            get { return numClientBox.Text; }
            set { numClientBox.Text = value; }
        }

        public string idValue
        {
            get { return this.idValue;  }
            set { this.idValue = value; }
        }

        private void saveButt_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm changes?", "Edit Event Details", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //string editQuery = "UPDATE event SET event_name = ,event_location = , event_notes = , start_date = , end_date = , start_time = , 
                //end_time = , client_name = , client_contact = WHERE id_event = " + idValue;
                //executeMyQuery(editQuery);
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {

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

        private void startMeri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
                
    }
}

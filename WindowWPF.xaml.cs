﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalManagment
{
    /// <summary>
    /// Logika interakcji dla klasy WindowWPF.xaml
    /// </summary>
    public partial class WindowWPF : Window
    {
        public WindowWPF()
        {
            InitializeComponent();

            HospitalManagementDBEntities db = new HospitalManagementDBEntities();

            var docs = from d in db.Doctors
                       select new
                       {
                           DoctorName = d.Name,
                           Speciality = d.Specialization,
                           Qualification = d.Qualification,
                           Gender = d.Gender
                       };

            foreach (var item in docs)
            {
                Console.WriteLine(item.DoctorName);
                Console.WriteLine(item.Speciality);
                Console.WriteLine(item.Qualification);
                Console.WriteLine(item.Gender);
            }

            this.gridDoctors.ItemsSource = docs.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            HospitalManagementDBEntities db = new HospitalManagementDBEntities();

            Doctor doctorObject = new Doctor()
            {
                Name = txtName.Text,
                Qualification = txtQualification.Text,
                Specialization = txtSpecialization.Text,
                Gender = txtGender.Text


            };

            db.Doctors.Add(doctorObject);
            db.SaveChanges();
        }

        private void BtnLoadDoctors_Click(object sender, RoutedEventArgs e)
        {
            HospitalManagementDBEntities db = new HospitalManagementDBEntities();

            this.gridDoctors.ItemsSource = db.Doctors.ToList();
        }

        private void gridDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(this.gridDoctors.SelectedItems);
        }

        private void BtnUpdateDoctors_Click(object sender, RoutedEventArgs e)
        {
            HospitalManagementDBEntities db = new HospitalManagementDBEntities();

            var r = from d in db.Doctors
                  where d.Id == 1
                  select d;
            
           foreach (var item in r)
            {
                MessageBox.Show(item.Name);
            }

        }
    }
}

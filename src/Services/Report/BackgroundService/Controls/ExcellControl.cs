using EnumsNET;
using ReportBackgroundService.Models;
using ReportBackgroundService.ServiceRestSharp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ReportBackgroundService.Controls
{
    public static class ExcellControl
    {
        public static List<ReportEnity> reportData()
        {
            //Rapor için gerekli dataları almak için directory servisine rest yöntemini kullandım
            var ContactInformations = DirectoryServiceApi<ContactInformationsEntity>.GetContactInformation(Method.GET, "ContactInformation/GetAll",null);
            var Persons = DirectoryServiceApi<PersonsEntity>.GetContactInformation(Method.GET, "Person/GetAll",null);

            var location = ContactInformations.Data.Where(p => p.informationType == GetEnumDescription(ContactInformationEnum.Location)).Select(p=>p.informationContent).ToList().Distinct().ToList();


            List<ReportEnity> reportEnities = new List<ReportEnity>();

            //Rapor datalarını oluşturmak için oluşturduğum algoritma.
            location.ForEach(prop =>
            {
                var per = ContactInformations.Data.Where(p => p.informationContent.ToLower() == prop.ToLower()).Select(p => p.personuuid).Distinct().ToList();
                
                var tel = ContactInformations.Data.Where(p => p.informationType == GetEnumDescription(ContactInformationEnum.TelephoneNumber)).ToList();
                reportEnities.Add(new ReportEnity
                {
                    LocationInformation = prop,
                    recordedPerson = per.Count(),
                    recordedTelephoneNumber = tel.Where(p => per.Contains(p.personuuid)).Count()
                });
            });

            return reportEnities;
        }

        // Enum açıklamalarını döndüren bir metot yazdım.
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}

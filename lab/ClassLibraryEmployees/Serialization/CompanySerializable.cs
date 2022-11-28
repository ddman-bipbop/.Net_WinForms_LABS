using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ClassLibraryEmployees.Serialization
{
    [Serializable]
    public class CompanySerializable
    {
        public List<Employees> Employeess { get; set; } = new List<Employees>();
        public List<TypeWork> TypeWorks { get; set; } = new List<TypeWork>();
        public List<WorkSerializable> Works { get; set; } = new List<WorkSerializable>();


        public static void Save(string fileName, SerializeType type)
        {
            var companySerializable = new CompanySerializable();
            var company = Company.Instance;
            foreach (var empl in company.Employeess)
            {
                companySerializable.Employeess.Add(empl);
            }
            foreach (var tWork in company.TypeWorks)
            {
                companySerializable.TypeWorks.Add(tWork);
            }
            foreach (var work in company.Works)
            {
                companySerializable.Works.Add(new WorkSerializable
                {
                    TypeWorkId = work.TypeWork.WorkInfo.NameWork,
                    EmployeesId = work.Employees.EmployeesId,
                    StartDate = work.StartDate,
                    EndDate = work.EndDate
                });
            }

            switch (type)
            {
                case SerializeType.XML:
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(CompanySerializable));
                    using (StreamWriter xmlStreamWriter = new StreamWriter(fileName))
                    {
                        xmlSerializer.Serialize(xmlStreamWriter, companySerializable);
                    }
                    break;
                case SerializeType.JSON:
                    using (StreamWriter jsonStreamWriter = File.CreateText(fileName))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer { Formatting = Formatting.Indented };
                        jsonSerializer.Serialize(jsonStreamWriter, companySerializable);
                    }
                    break;
                case SerializeType.Binary:
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream binaryFileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(binaryFileStream, companySerializable);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }


        public static void Load(string fileName, SerializeType type)
        {
            Employees.NewEmployeesId = 0;
            CompanySerializable companySerializable;
            switch (type)
            {
                case SerializeType.XML:
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(CompanySerializable));
                    StreamReader streamReader = new StreamReader(fileName);
                    companySerializable = (CompanySerializable)xmlSerializer.Deserialize(streamReader);
                    streamReader.Close();
                    break;
                case SerializeType.JSON:
                    StreamReader jsonStreamReader = File.OpenText(fileName);
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    companySerializable = (CompanySerializable)jsonSerializer.Deserialize(jsonStreamReader, typeof(CompanySerializable));
                    jsonStreamReader.Close();
                    break;
                case SerializeType.Binary:
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream binaryFileStream = new FileStream(fileName, FileMode.Open);
                    companySerializable = (CompanySerializable)formatter.Deserialize(binaryFileStream);
                    binaryFileStream.Close();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            var company = Company.Instance;
            var companyEmployees = company.Employeess.ToList();
            var companyTypeWork = company.TypeWorks.ToList();
            var companyWorks = company.Works.ToList();
            foreach (var cEmpl in companyEmployees)
            {
                company.RemoveEmpl(cEmpl.EmployeesId);
            }
            foreach (var cTypeWork in companyTypeWork)
            {
                company.RemoveTypeWork(cTypeWork.WorkInfo.NameWork);
            }
            foreach (var cWork in companyWorks)
            {
                company.RemoveWork(cWork);
            }
            var empls = new Dictionary<int, Employees>();
            var tWorks = new Dictionary<string, TypeWork>();
            int maxEmployeesId = 0;
            foreach (var employees in companySerializable.Employeess)
            {
                if (employees.EmployeesId > maxEmployeesId) maxEmployeesId = employees.EmployeesId;
                empls.Add(employees.EmployeesId, employees);
                company.AddEmpl(employees);
            }
            foreach (var typework in companySerializable.TypeWorks)
            {
                tWorks.Add(typework.WorkInfo.NameWork, typework);
                company.AddTypeWork(typework);
            }
            foreach (var work in companySerializable.Works)
            {
                company.AddWork(new Work
                {
                    Employees = empls[work.EmployeesId],
                    TypeWork = tWorks[work.TypeWorkId],
                    StartDate = work.StartDate,
                    EndDate = work.EndDate
                });
            }
            Employees.NewEmployeesId = maxEmployeesId;
        }
    }
}

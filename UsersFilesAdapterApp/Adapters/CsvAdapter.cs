using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersMettlerToledoApp.Adapters
{
    class CsvAdapter : FormatAdapter
    {
        public CsvAdapter(string filePath) : base(filePath)
        {
            FilePath = filePath;
        }

        public override void ReadFromFile()
        {
            using (var reader = new StreamReader(FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<User>();
                Users = records.ToList();
            }
        }
    }
}

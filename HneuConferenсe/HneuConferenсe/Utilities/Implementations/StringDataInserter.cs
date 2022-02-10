using System;
using System.Reflection;
using System.Text;

namespace HneuConferenсe.Utilities
{
    public class StringDataInserter : IDataInserter
    {
        public string InsertData(string source, object dataModel)
        {
            StringBuilder stringBuilder = new StringBuilder(source);
            Type dataModelType = dataModel.GetType();
            PropertyInfo[] dataModelProperties = dataModelType.GetProperties();

            foreach (PropertyInfo property in dataModelProperties)
            {
                string propertyName = property.Name;
                object propertyValue = property.GetValue(dataModel);
                stringBuilder.Replace($"{{{propertyName}}}", propertyValue.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}

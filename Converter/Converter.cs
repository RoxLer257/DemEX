using DemSerDar.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DemSerDar.Converter
{
    public class ProcentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                int ID = (int)value;
                int elem = 0;
                double purchCount = 0;

                foreach (var item in DemEXEntities.GetContext().Partners_import.ToList())
                {
                    foreach (var purchase in item.Partner_products_import)
                    {
                        if (purchase.IDNamePartner == ID)
                        {
                            purchCount += purchase.CountProduct;
                        }
                    }
                    elem++;
                }

                if (purchCount < 10000)
                {
                    return "0%";
                }
                else if (purchCount < 50000)
                {
                    return "5%";
                }
                else if (purchCount < 300000)
                {
                    return "10%";
                }
                else
                {
                    return "15%";
                }
            }
            else
            {
                return "0%";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

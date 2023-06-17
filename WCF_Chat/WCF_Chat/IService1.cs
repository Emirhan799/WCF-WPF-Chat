using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Chat
{
    // NOT: "IService1" arabirim adını kodda ve yapılandırma dosyasında birlikte değiştirmek için "Yeniden Düzenle" menüsündeki "Yeniden Adlandır" komutunu kullanabilirsiniz.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string MesajEkle(string value);

        [OperationContract]
        string MesajGetir();

        [OperationContract]
        void MesajlariSil();
    }


    // Hizmet işlemlerine bileşik türler eklemek için, aşağıdaki örnekte gösterildiği şekilde bir veri sözleşmesi kullanın.
    class GizliVeri
    {
        public double a { get; set; }

        public double b { get; set; }
    }

    [DataContract]
    class GorunenVeri
    {
        public double x { get; set; }

        [DataMember]
        public double a { get; set; }

        [DataMember]
        public double b { get; set; }
    }
}

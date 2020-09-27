using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace DatabaseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        DataSet Connect(string name);

        [OperationContract]
        DataSet SelectWithInt(string name, string parameter, int value);

        [OperationContract]
        DataSet SelectWithString(string name, string parameter, string value);

        [OperationContract]
        bool InsertTransactionBuy(string userID, string price, string purchase, string sellerID);

        [OperationContract]
        bool DeleteByID(string name, string id, string value);

        [OperationContract]
        void UpdateWithField(string table, string fieldName, string value, string idfield, string idvalue);

        [OperationContract]
        void execute(string query);

        [OperationContract]
        void UpdateWithDouble(string table, string fieldName, double value, string idfield, string idvalue);
    }
}

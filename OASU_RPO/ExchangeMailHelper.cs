using OASU_RPO.ru.crimeanpost;
using Feodosiya.Lib.Security;
using System;
using System.Net;


namespace OASU_RPO {
    public static class ExchangeMailHelper {

        /// <summary>
        /// Проверяет успешность подключения к серверу Exchange с указанными параметрами
        /// </summary>
        /// <param name="ex">Параметры подключения</param>
        /// <param name="message">Возвращает текст ошибки подключения при ее наличии</param>
        /// <returns></returns>
        public static bool CheckConnection(Configuration.Exchange ex, out string message) {
            try {
                message = string.Empty;

                ExchangeServiceBinding bind = new ExchangeServiceBinding();
                bind.Credentials = new NetworkCredential(ex.Username, ex.Password, ex.Domain);
                bind.Url = "https://" + ex.ServerName + "/EWS/Exchange.asmx";

                FindItemType findType = new FindItemType();
                findType.Traversal = ItemQueryTraversalType.Shallow;
                findType.ItemShape = new ItemResponseShapeType();
                findType.ItemShape.BaseShape = DefaultShapeNamesType.IdOnly;

                DistinguishedFolderIdType folder = new DistinguishedFolderIdType();
                folder.Id = DistinguishedFolderIdNameType.inbox;
                findType.ParentFolderIds = new BaseFolderIdType[] { folder };

                FindItemResponseType findResp = bind.FindItem(findType);
            }
            catch (Exception error) {
                message = error.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Выполняет поиск входящих писем с подтверждением об обработке файлов за указанный период
        /// </summary>
        /// <param name="begin">Дата начиная с которой будет происходить поиск писем</param>
        /// <returns></returns>
        public static ItemType[] GetMessages(DateTime begin) {
            ExchangeServiceBinding bind = new ExchangeServiceBinding();
            bind.Credentials = new NetworkCredential(AppHelper.Configuration.Exchange.Username.GetDecryptedString(),
                AppHelper.Configuration.Exchange.Password.GetDecryptedString(), AppHelper.Configuration.Exchange.Domain);
            bind.Url = "https://" + AppHelper.Configuration.Exchange.ServerName + "/EWS/Exchange.asmx";

            FindItemType findType = new FindItemType();
            findType.Traversal = ItemQueryTraversalType.Shallow;
            findType.ItemShape = new ItemResponseShapeType();
            findType.ItemShape.BaseShape = DefaultShapeNamesType.AllProperties;

            DistinguishedFolderIdType folder = new DistinguishedFolderIdType();
            folder.Id = DistinguishedFolderIdNameType.inbox;
            findType.ParentFolderIds = new BaseFolderIdType[] { folder };

            IsEqualToType isEq = new IsEqualToType();
            PathToUnindexedFieldType uPath = new PathToUnindexedFieldType();
            uPath.FieldURI = UnindexedFieldURIType.messageFrom;
            FieldURIOrConstantType constType = new FieldURIOrConstantType();
            ConstantValueType constValue = new ConstantValueType();
            constValue.Value = AppHelper.Configuration.Exchange.SenderName;
            constType.Item = constValue;
            isEq.Item = uPath;
            isEq.FieldURIOrConstant = constType;

            IsGreaterThanOrEqualToType isGrEq = new IsGreaterThanOrEqualToType();
            PathToUnindexedFieldType uPath2 = new PathToUnindexedFieldType();
            uPath2.FieldURI = UnindexedFieldURIType.itemDateTimeSent;
            FieldURIOrConstantType constType2 = new FieldURIOrConstantType();
            ConstantValueType constValue2 = new ConstantValueType();
            constValue2.Value = string.Format("{0}-{1}-{2}T00:00:00Z", begin.Year, begin.Month.ToString("D2"), begin.Day.ToString("D2"));
            constType2.Item = constValue2;
            isGrEq.Item = uPath2;
            isGrEq.FieldURIOrConstant = constType2;

            AndType and = new AndType();
            and.Items = new SearchExpressionType[] { isEq, isGrEq };

            findType.Restriction = new RestrictionType();
            findType.Restriction.Item = and;

            FindItemResponseType findResp = bind.FindItem(findType);
            FindItemResponseMessageType resMes = findResp.ResponseMessages.Items[0] as FindItemResponseMessageType;
            if (resMes.ResponseClass != ResponseClassType.Success) {
                throw new Exception("Ошибка при получении ответа от сервера Exchange:\n" + resMes.MessageText);
            }
            ItemType[] messages = (resMes.RootFolder.Item as ArrayOfRealItemsType).Items;

            return messages;
        }
    }
}

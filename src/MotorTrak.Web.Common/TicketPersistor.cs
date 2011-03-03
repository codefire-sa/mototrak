using System;
using System.IO;
using System.Text;
using MotoTrak.Entities;

namespace MotoTrak.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class TicketPersistor
    {
        #region [ Constructors ]

        /// <summary>
        /// 
        /// </summary>
        public TicketPersistor()
        {
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public string Serialize(SecurityTicket ticket)
        {
            MemoryStream serializationStream = null;
            BinaryWriter writer = null;
            byte[] buffer = null;

            if (ticket == null) return null;

            try
            {
                serializationStream = new MemoryStream();
                writer = new BinaryWriter(serializationStream);

                writer.Write(ticket.UserId);
                writer.Write(ticket.UserCode);
                writer.Write(ticket.UserName);
                writer.Write(ticket.DealerId);

                buffer = serializationStream.ToArray();
            }
            finally
            {
                if (serializationStream != null)
                {
                    serializationStream.Close();
                }
            }

            return Convert.ToBase64String(buffer);
        }

        public SecurityTicket Deserialize(string data)
        {
            MemoryStream dataStream = null;
            BinaryReader reader = null;

            var ticket = new SecurityTicket();
            if (string.IsNullOrEmpty(data)) return ticket;


            var buffer = Convert.FromBase64String(data);
            try
            {
                dataStream = new MemoryStream(buffer);
                reader = new BinaryReader(dataStream);

                ticket.UserId = reader.ReadInt32();
                ticket.UserCode = reader.ReadString();
                ticket.UserName = reader.ReadString();
                ticket.DealerId = reader.ReadInt32();
            }
            finally
            {
                if (dataStream != null)
                {
                    dataStream.Close();
                }
            }

            return ticket;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class Journal
    {
        protected List<JournalEntry> journalList;
        protected class JournalEntry
        {
            public string Name { get; }
            public string CollectionChangeType { get; }
            public string ObjectInformation { get; }
            public JournalEntry(string name, string collectionChangeType, string objectInformation)
            {
                Name = name;
                CollectionChangeType = collectionChangeType;
                ObjectInformation = objectInformation;
            }
            public override string ToString()
            {
                string outString = "";
                outString += "Collection name: " + Name + '\n'
                    + "Collection change type: " + CollectionChangeType + '\n'
                    + "Object information: " + ObjectInformation + '\n'
                    + "\t<<--------->>\n" + '\n';
                return outString;
            }
        }

        public Journal()
        {
            journalList = new List<JournalEntry>();
        }

        protected void Add(JournalEntry je)
        {
            journalList.Add(je);
        }

        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs args)
        {
            var je = new JournalEntry(args.NameOfCollection, args.TypeOfChange, args.ChaingedObj.ToString());
            this.Add(je);
        }
        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs args)
        {
            var je = new JournalEntry(args.NameOfCollection, args.TypeOfChange, args.ChaingedObj.ToString());
            this.Add(je);
        }

        public override string ToString()
        {
            string outString = "";
            outString += "\t\t<<JournalStart>>" + "\n\n";

            foreach (JournalEntry je in journalList)
                outString += je.ToString();


            outString += "\t\t<<JournalEnd>>" + '\n';

            return outString;
        }





    }
}

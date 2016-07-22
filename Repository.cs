using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{


    public class PWDList
    {
        //THE REPOSITORY OF IDENTITIES

        public List<Identity> repository = new List<Identity>();


        //ADD TO LIST
        public void addElement(Identity NIdentity)
        {
            repository.Add(NIdentity);
        }
        //REMOVE FROM LIST
        public void removeElement(int ID)
        {                                                     
            Identity obj = GetIdentityWithID(ID);
            Identity Validation = new Identity();
            Validation.Init_Identity(-1, "NA", "NA", "NA");

            //for (int i = this.getListIndexOfIdentity(obj); i < this.repository.Count; i++)
            //{
            //    int id = repository[i].getID();
            //    id--;
            //    repository[i].setID(id);
            //}

            if (obj != Validation)
            {
                repository.Remove(obj);
            }

        }
                               

        public int getListIndexOfIdentity(Identity id)
        {
            for (int i = 0; i < repository.Count; i++)
            {
                if (repository[i].getWebsite() == id.getWebsite())
                {
                    return i;
                }
            }
            return -1;
        }

        //GET THE OBJECT WITH AN ID
        public Identity GetIdentityWithID(int ID)
        /*
        Function returns the object if it was found
        if not found, the function will return an object with ID=-1, and the string fields all equal to NA
        */
        {
            bool found = false;
            int i;
            for (i = 0; i < repository.Count; i++)
            {
                if (repository[i].getID() == ID)
                {
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                return repository[i];
            }
            else
            {
                Identity RetIdentity = new Identity();
                RetIdentity.Init_Identity(-1, "NA", "NA", "NA");
                return RetIdentity;
            }
        }
        /*
public Identity GetFirstIdentity()
{
Identity RetIdentity = new Identity();
try
{
 RetIdentity = repository[0];
}
catch (Exception)
{
 RetIdentity.Init_Identity(-1, "NA", "NA", "NA");
}
return RetIdentity;
}                            */

        public int length()
        {
            return repository.Count;
        }

        public string addToListBox(Identity NIdentity)
        {
            //n.id.  n.website
            string ListBoxString = NIdentity.getID().ToString() + ".  " + NIdentity.getWebsite();       
            return ListBoxString;
        }

        public int generateValidID()
        {
            //return this.repository.Count();
            int idx = 0;
            Boolean found = false;
            while (found == false)
            {
                Boolean available = true;
                foreach (Identity i in repository)
                {
                    if (i.getID() == idx)
                        available = false;
                }
                if (available == true)
                    found = true;
                idx++;
            }
            idx--;
            return idx;
        }

        public Identity getIdentityWithID(int idx)
        {                                    
            foreach (Identity id in this.repository)
            {
                if (id.getID() == idx)
                {
                    return id;
                }
            }
            Identity id_err = new Identity();
            id_err.Init_Identity(0, "NA", "NA", "NA");
            return id_err;
        }

        public List<Identity> getAll()
        {
            return this.repository;
        }
    }



}

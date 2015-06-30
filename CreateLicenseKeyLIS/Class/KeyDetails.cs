using System;
using System.Collections.Generic;
using System.Text;

namespace CreateLicenseKeyLIS
{
    class KeyDetails
    {

        bool m_blnExpires;


        private bool m_blnIsValid;

        private DateTime m_dteDateValidThrough;

        private DateTime m_dteDateCreated;

        public bool Expires
        {
            get
            {
                return m_blnExpires;
            }
            set
            {
                m_blnExpires = value;
            }
        }

        public bool IsValid
        {
            get
            {
                return m_blnIsValid;
            }
            set
            {
                m_blnIsValid = value;
            }
        }

        public DateTime DateValidThrough
        {
            get
            {
                return m_dteDateValidThrough;
            }
            set
            {
                m_dteDateValidThrough = value;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return m_dteDateCreated;
            }
            set
            {
                m_dteDateCreated = value;
            }
        }



    }
}

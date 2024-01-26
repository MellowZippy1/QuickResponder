using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickResponder.Domain
{
    public class MedicalDevice
    {
        /* 
         * Class 1: Low-risk devices (Bandages & Wheelchairs etc.)
         * Class 2: Intermediate-risk devices (Infusions pumps for intravenous medications)
         * Class 3: High-risk devices (Pacemakers, deep-brain stimulators)
         * Source: https://jamanetwork.com/journals/jama/fullarticle/1817798
         */

        public int Class { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBirds.CP.CommonCode
{
    public class HelpRegistrar : Attribute
    {
        bool _isControler;
        Type _type;
        string _controllerName;
        public HelpRegistrar(string controllerName)
        {
            _isControler = true;
        }
        public HelpRegistrar(string controllerName, Type returnType)
        {
            _isControler = false;
            this._type = returnType;

        }
        public bool IsControler { get { return _isControler; } }
        public Type Type { get { return _type; } }
        public string ControlerName { get { return _controllerName; } }
    }
}

using System;

namespace Orchestra.Controllers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NeverRegisterAttribute : Attribute
    {

    }
}

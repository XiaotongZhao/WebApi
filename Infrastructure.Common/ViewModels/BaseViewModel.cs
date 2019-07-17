using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.ViewModels
{
    public abstract class BaseViewModel<Tkey>
    {
        public Tkey Id { get; set; }
    }
}

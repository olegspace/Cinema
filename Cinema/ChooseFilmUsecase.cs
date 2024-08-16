using CinemaApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    internal class ChooseFilmUsecase
    {
        private ChooseFilmController controller = new ChooseFilmController();
        private ChooseFilmForm form;    
        public ChooseFilmUsecase() 
        {
            form = new ChooseFilmForm(controller);
        }

        public Form Runnable() 
        {
            return form;
        }
    }
}

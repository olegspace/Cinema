using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class PlaceOfCinemaHall: Button
    {
        public event EventHandler<ButtonStateEventArgs> ButtonClicked;

        private bool isPlaced = false;
        private Point placePosition = new Point();
        private int cost = 0;
        public bool IsPlaced { get => isPlaced; set => isPlaced = value; }
        public Point PlacePosition { get => placePosition; set => placePosition = value; }

        public Point GetPlacePosition()
        { return PlacePosition; }

        public PlaceOfCinemaHall(Point placePosition, bool state, int cost)
        {
            this.cost = cost;
            Click += ToggleOccupied;
            Font = new Font("Arial", 8, FontStyle.Regular);
            this.PlacePosition = placePosition;
            Dock = DockStyle.Fill;
            Text = "р:" + $"{placePosition.X + 1}" + "м:" + $"{placePosition.Y + 1}" + "\n" + $"{cost}р.";
            BackColor = System.Drawing.Color.Gray;

            IsPlaced = state;
            UpdateAppearance();
        }

        private void ToggleOccupied(object sender, EventArgs e)
        {
            IsPlaced = !IsPlaced;
            UpdateAppearance();
            ButtonStateEventArgs eventArgs = new ButtonStateEventArgs(IsPlaced);
            ButtonClicked?.Invoke(this, eventArgs);
        }

        private void UpdateAppearance()
        {
            if (IsPlaced)
            {
                BackColor = System.Drawing.Color.Red;
                Text = "Занято";
            }
            else
            {
                BackColor = System.Drawing.Color.Gray;
                Text = "р:" + $"{placePosition.X + 1}" + "м:" + $"{placePosition.Y + 1}" + "\n" + $"{cost}р.";
            }
        }
    }

    public class ButtonStateEventArgs : EventArgs
    {
        public bool isPlaced { get; }

        public ButtonStateEventArgs(bool isPlaced)
        {
            this.isPlaced = isPlaced;
        }
    }
}

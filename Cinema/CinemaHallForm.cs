using Cinema;
using System;
using System.Windows.Forms;

public class CinemaHallForm : Form
{
    /// <summary>
    /// Поле с данными о суммарной стоимости выбранных оператором мест.
    /// </summary>
    private int TotalSum = 0;

    /// <summary>
    /// Лейбл с данными о суммарной стоимости выбранных оператором мест.
    /// </summary>
    private Label TotalSumLabel = new Label();

    /// <summary>
    /// Котроллер для связи с данными о показе.
    /// </summary>
    // TODO: Подложить интерфейс для унификации связи между представлением и моделью.
    private FilmSessionController controller;

    private int rows;
    private int cols;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rows">Ширина рядов в кинозале показа.</param>
    /// <param name="cols">Количество рядов в кинозале показа.</param>
    /// <param name="controller">Объект, определяющий и реализующий интерфейс для связи представления кинопоказа с данными модели.</param>
    public CinemaHallForm(FilmSessionController controller)
    {
        this.controller = controller;

        Text = "Кинозал";
        AutoSize = true;
        this.WindowState = FormWindowState.Maximized;

        Label screenLabel = new Label();
        screenLabel.Text = "ЭКРАН";
        screenLabel.Dock = DockStyle.Top;
        screenLabel.BackColor = System.Drawing.Color.Blue;
        screenLabel.ForeColor = System.Drawing.Color.White;
        screenLabel.TextAlign = ContentAlignment.MiddleCenter;

        TableLayoutPanel layout = new TableLayoutPanel();
        layout.Dock = DockStyle.Fill;

        rows = controller.Height();
        cols = controller.Width();

        layout.ColumnCount = cols;
        layout.RowCount = rows;

        layout.ColumnStyles.Clear();
        layout.RowStyles.Clear();
 
        for (int col = 0; col < cols; col++)
        {
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / rows));
        }
        for (int row = 0; row < rows; row++)
        {
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
        }

        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                Point pos = new Point(row, col);
                PlaceOfCinemaHall toggleButton = new PlaceOfCinemaHall(pos, controller.IsPlaced(pos), controller.GetPrice(pos));
                toggleButton.ButtonClicked += ToggleButton_ButtonClicked;
                layout.Controls.Add(toggleButton, col, row);
            }
        }

        TableLayoutPanel bottomLayout = new TableLayoutPanel();
        bottomLayout.Dock = DockStyle.Bottom;
        bottomLayout.ColumnCount = 2;
        bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
        bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

        this.TotalSumLabel.AutoSize = true;
        UpdateTotalSumLable();

        Button confirmButton = new Button();
        confirmButton.Text = "Подтвердить";
        confirmButton.Dock = DockStyle.Fill;
        confirmButton.Click += ConfirmButton_Click;

        bottomLayout.Controls.Add(this.TotalSumLabel, 0, 0);
        bottomLayout.Controls.Add(confirmButton, 1, 0);

        Controls.Add(layout);
        Controls.Add(screenLabel);
        Controls.Add(bottomLayout);
    }
    private void ToggleButton_ButtonClicked(object sender, ButtonStateEventArgs e)
    {
        PlaceOfCinemaHall button = (PlaceOfCinemaHall)sender;
        Console.WriteLine(button.IsPlaced);

        if (e.isPlaced)
        {
            button.BackColor = System.Drawing.Color.Red;
            button.Text = "Занято";
            LockPlace(button.GetPlacePosition());
            TotalSum += GetPrice(button.GetPlacePosition());
            UpdateTotalSumLable();
        }
        else
        {
            UnlockPlace(button.GetPlacePosition());
            TotalSum -= GetPrice(button.GetPlacePosition());
            UpdateTotalSumLable();
        }
    }

    private void UpdateTotalSumLable()
    {
        this.TotalSumLabel.Text = "TotalSum:" + TotalSum.ToString();
    }
    private int GetPrice(Point pos) 
    {
        return this.controller.GetPrice(pos);
    }

    private void LockPlace(Point pos)
    {
        this.controller.LockPlace(pos);
    }

    private void UnlockPlace(Point pos)
    {
        this.controller.UnlockPlace(pos);
    }


    private void ConfirmButton_Click(object sender, EventArgs e)
    {
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                Point pos = new Point(row, col);

                Console.WriteLine(pos.ToString() + " " + controller.IsPlaced(pos));
            }
        }

        Close();
    }
}

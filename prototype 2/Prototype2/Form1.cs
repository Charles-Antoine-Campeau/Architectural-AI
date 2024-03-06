
namespace Prototype2
{
    public partial class Main : Form
    {
        // a list to keep every room
        readonly RoomList roomList;
        public Main()
        {
            InitializeComponent();
            roomList = new RoomList();
        }

        /// <summary>
        /// On click listener for BtnOpenCSV Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenCSV_Click(object sender, EventArgs e)
        {
            // Create a file explorer to find the CSV with the room data
            OpenFileDialog openFileDialog1 = new()
            {
                Title = "Get CSV with room data",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "csv",
                Filter = "CSV files (*.csv)|*.csv",
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            // Execute only if a file was selected
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DisplayText("Fetched file: " +  openFileDialog1.FileName);

                // read the file 
                using var reader = new StreamReader(openFileDialog1.FileName);

                DisplayText("***** ***** ***** *****");
                DisplayText("File data:");

                // add each room from the file to the list
                while (!reader.EndOfStream)
                {
                    // read the next line
                    var line = reader.ReadLine();
                    DisplayText(line);

                    // split the data into an array and get the dimensions
                    string[] values = line.Split(",");
                    int[] dimentions = new int[] { int.Parse(values[1]), int.Parse(values[2]) };

                    // add the room to the list
                    roomList.AddRoom(
                        values[0],
                        dimentions,
                        (RoomList.Shape)Enum.Parse(typeof(RoomList.Shape), values[3].ToUpper()),
                        (RoomList.Position)Enum.Parse(typeof(RoomList.Position), values[4].ToUpper())
                        );
                }

                DisplayText("End of File");
                DisplayText("***** ***** ***** *****");
            }
        }

        /// <summary>
        /// On click Listeter for BtnGenerate button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            // create a new plan object
            PlanDrawer plan = new(roomList);
        }

        /// <summary>
        /// Display text in the textbox of the main menu and add a new line after
        /// </summary>
        /// <param name="text">The text to display</param>
        public void DisplayText(string text)
        {
            DisplayBox.AppendText(text);
            DisplayBox.AppendText(Environment.NewLine);
        }
    }
}

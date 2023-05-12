using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourseWork9
{
    /// <summary>
    /// Главная форма.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Поля

        /// <summary>
        /// Делимое А.
        /// </summary>
        private ushort _a;

        /// <summary>
        /// Делитель В.
        /// </summary>
        private ushort _b;

        /// <summary>
        /// Управляющий автомат.
        /// </summary>
        private readonly ManageMachine _manageMachine;

        /// <summary>
        /// МикроПрограмма.
        /// </summary>
        private readonly MicroProgram _microProgram;

        #endregion

        /// <summary>
        /// Инициализация формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _manageMachine = new ManageMachine(this);
            _microProgram = new MicroProgram(this);

            dataGridView_A.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView_B.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView_C.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView_D.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView_AM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView_BM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView_Count.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dataGridView_A.Font = new Font("Microsoft Sans Serif", 8);
            dataGridView_B.Font = new Font("Microsoft Sans Serif", 8);
            dataGridView_C.Font = new Font("Microsoft Sans Serif", 8);
            dataGridView_D.Font = new Font("Microsoft Sans Serif", 8);
            dataGridView_AM.Font = new Font("Microsoft Sans Serif", 8);
            dataGridView_BM.Font = new Font("Microsoft Sans Serif", 8);
            dataGridView_Count.Font = new Font("Microsoft Sans Serif", 8);
            const int widthColumn = 25;
            var width = 0;

            for (var i = 4 - 1; i >= 0; i--)
            {
                var index = dataGridView_Count.Columns.Add("column_" + i, i.ToString());
                dataGridView_Count.Columns[index].Width = widthColumn;
                width += widthColumn;
            }

            dataGridView_Count.Height = 45;
            dataGridView_Count.Width = width + 3;
            width = 0;

            for (var i = 16 - 1; i >= 0; i--)
            {
                var index = dataGridView_A.Columns.Add("column_" + i, i.ToString());
                dataGridView_B.Columns.Add("column_" + i, i.ToString());
                dataGridView_A.Columns[index].Width = widthColumn;
                dataGridView_B.Columns[index].Width = widthColumn;
                width += widthColumn;
            }

            dataGridView_A.Height = 45;
            dataGridView_A.Width = width + 2;
            dataGridView_B.Height = 45;
            dataGridView_B.Width = width + 3;
            width = 0;

            for (var i = 32 - 1; i >= 0; i--)
            {
                var index = dataGridView_C.Columns.Add("column_" + i, i.ToString());
                dataGridView_AM.Columns.Add("column_" + i, i.ToString());
                dataGridView_BM.Columns.Add("column_" + i, i.ToString());
                dataGridView_D.Columns.Add("column_" + i, i.ToString());
                dataGridView_AM.Columns[index].Width = widthColumn;
                dataGridView_BM.Columns[index].Width = widthColumn;
                dataGridView_C.Columns[index].Width = widthColumn;
                dataGridView_D.Columns[index].Width = widthColumn;
                width += widthColumn;
            }

            dataGridView_AM.Height = 45;
            dataGridView_AM.Width = width + 3;
            dataGridView_BM.Height = 45;
            dataGridView_BM.Width = width + 3;
            dataGridView_C.Height = 45;
            dataGridView_C.Width = width + 3;
            dataGridView_D.Height = 45;
            dataGridView_D.Width = width + 3;

            dataGridView_A.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            dataGridView_B.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            dataGridView_AM.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            dataGridView_BM.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            dataGridView_C.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            dataGridView_D.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            dataGridView_Count.Rows.Add(0, 0, 0, 0);

            dataGridView_A.BorderStyle = dataGridView_B.BorderStyle = dataGridView_C.BorderStyle =
                dataGridView_D.BorderStyle = dataGridView_AM.BorderStyle = dataGridView_BM.BorderStyle =
                    dataGridView_Count.BorderStyle = BorderStyle.FixedSingle;

            dataGridView_A.RowHeadersVisible = dataGridView_B.RowHeadersVisible = dataGridView_AM.RowHeadersVisible =
                dataGridView_BM.RowHeadersVisible = dataGridView_C.RowHeadersVisible =
                    dataGridView_D.RowHeadersVisible = dataGridView_Count.RowHeadersVisible = false;

            dataGridView_A.RowsDefaultCellStyle.Alignment = dataGridView_B.RowsDefaultCellStyle.Alignment =
                dataGridView_C.RowsDefaultCellStyle.Alignment = dataGridView_Count.RowsDefaultCellStyle.Alignment =
                    dataGridView_AM.RowsDefaultCellStyle.Alignment = dataGridView_BM.RowsDefaultCellStyle.Alignment =
                        dataGridView_D.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            UpdateStateMemory(0);
        }

        #region Отображение данных

        /// <summary>
        /// Обновление визуальной части регистров.
        /// </summary>
        /// <param name="am">Обновляемый регистр AM.</param>
        /// <param name="bm">Обновляемый регистр ВM.</param>
        /// <param name="count">Счетчик.</param>
        /// <param name="c">Обновляемый регистр С.</param>
        /// <param name="d">Обновляемый регистр D.</param>
        public void UpdateInfoRegister(uint am, uint bm, uint d, uint c, byte count)
        {
            // update info register AM.
            UpdateInfoRegister(dataGridView_AM, am, 32);

            // update info register BM.
            UpdateInfoRegister(dataGridView_BM, bm, 32);

            // update info register D.
            UpdateInfoRegister(dataGridView_D, d, 32);

            // update Count.
            UpdateInfoRegister(dataGridView_Count, count, 4);

            // update info about number C.
            var bufferRes = Convert.ToString(c, 2).PadLeft(32, '0');

            for (var i = 32 - 1; i >= 0; i--)
                dataGridView_C.Rows[0].Cells[i].Value = bufferRes[i];
        }

        /// <summary>
        /// Обновление визуальной части регистров.
        /// </summary>
        /// <param name="table">Таблица с данными.</param>
        /// <param name="value">Число в ushort.</param>
        /// <param name="count">Количество разрядов.</param>
        private static void UpdateInfoRegister(DataGridView table, ushort value, short count)
        {
            var result = Convert.ToString(value, 2).PadLeft(count, '0');
            for (var i = count - 1; i >= 0; i--)
                table.Rows[0].Cells[i].Value = result[i];
        }

        /// <summary>
        /// Обновление визуальной части регистров.
        /// </summary>
        /// <param name="table">Таблица с данными.</param>
        /// <param name="value">Число в uint.</param>
        /// <param name="count">Количество разрядов.</param>
        private static void UpdateInfoRegister(DataGridView table, uint value, short count)
        {
            var result = Convert.ToString(value, 2).PadLeft(count, '0');
            for (var i = count - 1; i >= 0; i--)
                table.Rows[0].Cells[i].Value = result[i];
        }

        /// <summary>
        /// Обновление состояния автомата.
        /// </summary>
        /// <param name="state">Массив с метками состояний.</param>
        public void UpdateStateMemory(bool[] state)
        {
            radioButton_A0.Checked = state[0];
            radioButton_A1.Checked = state[1];
            radioButton_A2.Checked = state[2];
            radioButton_A3.Checked = state[3];
            radioButton_A4.Checked = state[4];
            radioButton_A5.Checked = state[5];
            radioButton_A6.Checked = state[6];
            radioButton_A7.Checked = state[7];
            radioButton_A8.Checked = state[8];
            radioButton_A9.Checked = state[9];

            for (var i = 0; i < state.Length; i++)
                checkedListBox_A.SetItemChecked(i, state[i]);
        }

        /// <summary>
        /// Обновление состояния автомата.
        /// </summary>
        /// <param name="a">Номер метки.</param>
        public void UpdateStateMemory(ushort a)
        {
            radioButton_A0.Checked = a == 0;
            radioButton_A1.Checked = a == 1;
            radioButton_A2.Checked = a == 2;
            radioButton_A3.Checked = a == 3;
            radioButton_A4.Checked = a == 4;
            radioButton_A5.Checked = a == 5;
            radioButton_A6.Checked = a == 6;
            radioButton_A7.Checked = a == 7;
            radioButton_A8.Checked = a == 8;
            radioButton_A9.Checked = a == 9;
        }

        /// <summary>
        /// Обновление значений в комбинационных схемах.
        /// </summary>
        /// <param name="t">Терма.</param>
        /// <param name="y">Выходные сигналы из КСУ.</param>
        /// <param name="d">Выходные сигналы из КСD.</param>
        /// <param name="x">Выходные логические состояния из ОА.</param>
        public void UpdateInfoKc(bool[] t, bool[] y, bool[] d, bool[] x)
        {
            for (var i = 0; i < t.Length; i++)
                checkedListBox_T.SetItemChecked(i, t[i]);
            for (var i = 0; i < y.Length; i++)
                checkedListBox_Y.SetItemChecked(i, y[i]);
            for (var i = 0; i < d.Length; i++)
                checkedListBox_D.SetItemChecked(i, d[i]);
            for (var i = 0; i < x.Length; i++)
                checkedListBox_X.SetItemChecked(i, x[i]);
        }

        /// <summary>
        /// Обновление текущего состояния.
        /// </summary>
        /// <param name="dt">Текущее состояние.</param>
        public void UpdateInfoState(bool[] dt)
        {
            for (var i = 0; i < dt.Length; i++)
                checkedListBox_Dt.SetItemChecked(i, dt[i]);
        }

        /// <summary>
        /// Обновление значений в ПЛУ.
        /// </summary>
        /// <param name="x">Выходные логические состояния из ОА.</param>
        public void UpdateInfoPly(bool[] x)
        {
            for (int i = 0, q = 0; i < x.Length; i++)
            {
                if (i == 0
                    || i == 1
                    || i == 4
                    || i == 5
                    || i == 6)
                {
                    continue;
                }

                checkedListBox_Ply.SetItemChecked(q, x[i]);
                q++;
            }
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Обработчик нажатия на кнопку "Такт".
        /// </summary>
        private void button_Tact_Click(object sender, EventArgs e)
        {
            if (checkBox_x0_1.Checked)
            {
                if (radioButton_YA.Checked)
                {
                    if (radioButton_AutoMode.Checked)
                    {
                        _manageMachine.InputData(_a, _b);
                        _manageMachine.AutomaticMode();
                    }
                    else
                    {
                        _manageMachine.InputData(_a, _b);
                        _manageMachine.Step();
                    }
                }
                else
                {
                    if (radioButton_AutoMode.Checked)
                    {
                        _microProgram.InputData(_a, _b);
                        _microProgram.AutomaticMode();
                    }
                    else
                    {
                        _microProgram.InputData(_a, _b);
                        _microProgram.Step();
                    }
                }
            }
        }

        /// <summary>
        /// Сброс данных на регистрах.
        /// </summary>
        private void button_Reset_Click(object sender, EventArgs e)
        {
            _manageMachine.Reset();
            _microProgram.Reset();
            UpdateInfoRegister(0, 0, 0, 0, 0);
            UpdateStateMemory(0);
        }
        
        /// <summary>
        /// Сброс данныз на регистре А.
        /// </summary>
        private void button_reset_A_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < dataGridView_A.Rows[0].Cells.Count; i++)
            {
                dataGridView_A.Rows[0].Cells[i].Value = 0;
            }

            _a = 0;
        }

        /// <summary>
        /// Сброс данных на регистре B.
        /// </summary>
        private void button_reset_B_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < dataGridView_B.Rows[0].Cells.Count; i++)
            {
                dataGridView_B.Rows[0].Cells[i].Value = 0;
            }

            _b = 0;
        }

        #endregion

        #region Обработчики событий

        /// <summary>
        /// Обработчик события: нажате на разрядную сетку делимого (A).
        /// </summary>
        private void dataGridView_A_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var value = (int)dataGridView_A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            value = value == 0 ? 1 : 0;
            dataGridView_A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
            var cells = dataGridView_A.Rows[e.RowIndex].Cells;
            var strB = new StringBuilder();
            for (var i = 0; i < cells.Count; i++)
                strB.Append(cells[i].Value);

            var denial = false;
            ushort a = 0;
            if ((int)cells[0].Value == 1)
            {
                a = (ushort)Convert.ToInt16(strB.ToString(), 2);
                strB.Replace("1", "0", 0, 1);
                denial = true;
            }

            _a = (ushort)Convert.ToInt16(strB.ToString(), 2);
            _a = denial ? a : _a;
        }

        /// <summary>
        /// Обработчик события: нажате на разрядную сетку делителя (B).
        /// </summary>
        private void dataGridView_B_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var value = (int)dataGridView_B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            value = value == 0 ? 1 : 0;
            dataGridView_B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
            var cells = dataGridView_B.Rows[e.RowIndex].Cells;
            var strB = new StringBuilder();
            for (var i = 0; i < cells.Count; i++)
                strB.Append(cells[i].Value);

            var denial = false;
            ushort b = 0;
            if ((int)cells[0].Value == 1)
            {
                b = (ushort)Convert.ToInt16(strB.ToString(), 2);
                strB.Replace("1", "0", 0, 1);
                denial = true;
            }

            _b = (ushort)Convert.ToInt16(strB.ToString(), 2);
            _b = denial ? b : _b;
        }

        private void checkBox_x0_0_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_x0_0.Checked)
                checkBox_x0_1.Checked = false;
        }

        private void checkBox_x0_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_x0_1.Checked)
                checkBox_x0_0.Checked = false;
        }

        #endregion
    }
}
using System;

namespace CourseWork9
{
    public abstract class AbstractMachine
    {
        #region Свойства

        /// <summary>
        /// Делимое.
        /// </summary>
        protected ushort A { get; set; }

        /// <summary>
        /// Делитель.
        /// </summary>
        protected ushort B { get; set; }

        /// <summary>
        /// Частное.
        /// </summary>
        public uint C { get; internal set; }

        /// <summary>
        /// Регистр AM.
        /// </summary>
        public uint Am { get; internal set; }

        /// <summary>
        /// Регистр BM.
        /// </summary>
        public uint Bm { get; internal set; }

        /// <summary>
        /// Регистр D.
        /// </summary>
        public uint D { get; internal set; }

        /// <summary>
        /// Счетчик.
        /// </summary>
        public byte Count { get; private set; }

        /// <summary>
        /// Переполнение.
        /// </summary>
        private bool OverFlow { get; set; }

        /// <summary>
        /// Конец автоматата.
        /// </summary>
        public bool Run { get; internal set; } = true;

        /// <summary>
        /// Вектор результата логических условий. 
        /// </summary>
        public bool[] X { get; }

        /// <summary>
        /// Микрооперации.
        /// </summary>
        internal readonly Action[] Operations;

        protected AbstractMachine()
        {
            X = new bool[7];

            X[0] = true;

            Operations = new Action[]
            {
                () => { Am = (uint)(A << 15); }, // y0.
                () => { Am = Am >> 15 << 15; },
                () => { Bm = (uint)(B << 15); },
                () => { Bm = Bm >> 15 << 15; }, // y3.

                () => { Am = (~Bm | 0xC0000000) + Am + 0x1; }, // y4.
                () => { Am += Bm << 2 >> 2; },
                () => { D = Am; },
                () => { Bm >>= 1; }, // y7.

                () => { C = 0; }, // y8.
                () => { Count = 0; },
                () => { C = (C << 1) + 0x1; },
                () => { C <<= 1; }, // y11.

                () => { Am = D; }, // y12.
                () =>
                {
                    Count = (byte)(Count == 0
                        ? 15
                        : Count - 1);
                },
                () =>
                {
                    var buffer = (C + 0x2) << 15 >> 15;
                    C = (C >> 16 << 16) + buffer;
                },
                () => { C |= 0x10000; }, // y15.

                () => { Run = false; }, // y16.
                () => { OverFlow = true; }
            };
        }

        #endregion

        /// <summary>
        /// Такт.
        /// </summary>
        public abstract void Step();

        /// <summary>
        /// Вычисление логического результата каждого логического блока. 
        /// </summary>
        internal void LogicalDevice()
        {
            X[1] = Bm == 0;
            X[2] = Am == 0;
            X[3] = Am >> 31 == 1;
            X[4] = Count == 0;
            X[5] = (C & 0x1) == 1;
            X[6] = ((A & 0x1) ^ (B & 0x1)) == 1;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace SE.Common.Types
{
    public enum FirstLetters
    {
        A = 1,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J = 10,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T = 20,
        U,
        V,
        W,
        X,
        Y,
        Z = 26,
        [DisplayText("0-9")]
        Digit
    }
}

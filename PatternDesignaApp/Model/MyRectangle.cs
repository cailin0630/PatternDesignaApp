using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PatternDesignaApp.Model
{
    class MyRectangle:System.Windows.Shapes.Shape
    {
        protected override Geometry DefiningGeometry { get; }
    }
}

using CoreAnimation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UIKit;

namespace EsMo.iOS.Support
{
    public static class Printer
    {
        public static void Print(IEnumerable<NSLayoutConstraint> constraints)
        {
            foreach (var item in constraints)
            {
                item.Print();
            }
        }
        public static void Print(this NSLayoutConstraint constraint)
        {
            Debug.WriteLine("FirstItem={0},FirstAttr={1},Constant={2},SecondItem={3},SecondAttr={4}"
                , constraint.FirstItem, constraint.FirstAttribute, constraint.Constant, constraint.SecondItem, constraint.SecondAttribute);
        }
        public static void Print(this CALayer layer)
        {
            //Debug.WriteLine(string.Format("{0}", layer.GravityRight));
            if(layer.Filters!=null)
                foreach (var item in layer.Filters)
                {
                    Debug.WriteLine(item.OutputImage);
                }
        }
    }
}
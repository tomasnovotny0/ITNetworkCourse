using System;

namespace CSharpCourse.Cviceni13 {
    
    public static class Prevodnik {

        public static double PrevedNaStupne(double radiany) {
            return radiany * (180 / Math.PI);
        }

        public static double PrevedNaRadiany(double stupne) {
            return stupne * (Math.PI / 180);
        }
    }
}
﻿// This is an autogenerated file

using System;
using System.Linq.Expressions;

namespace Expressive
{
    public static class ExpressionCallExtension
    {
        public static TResult Call<TResult>(
            this Expression<Func<TResult>> expression)
        {
            var compiled = expression.ToFunc();

            return compiled();
        }

        public static TResult Call<T1, TResult>(
            this Expression<Func<T1, TResult>> expression, T1 p1)
        {
            var compiled = expression.ToFunc();

            return compiled(p1);
        }

        public static TResult Call<T1, T2, TResult>(
            this Expression<Func<T1, T2, TResult>> expression, T1 p1, T2 p2)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2);
        }

        public static TResult Call<T1, T2, T3, TResult>(
            this Expression<Func<T1, T2, T3, TResult>> expression, T1 p1, T2 p2, T3 p3)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3);
        }

        public static TResult Call<T1, T2, T3, T4, TResult>(
            this Expression<Func<T1, T2, T3, T4, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4);
        }

        public static TResult Call<T1, T2, T3, T4, T5, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6, p7);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6, p7, p8);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6, p7, p8, p9);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);
        }

        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>> expression, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16)
        {
            var compiled = expression.ToFunc();

            return compiled(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);
        }

    }
}

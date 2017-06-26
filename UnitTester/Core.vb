Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports GeminiLab.Core

<TestClass()> Public Class Core

    <TestMethod()> Public Sub Range()
        Dim r = New Range(10)
        Dim r2 = New Range(0, 10)

        Assert.IsTrue(r.SequenceEqual(r2))

        Dim rv = New Range(9, -1)

        Assert.IsTrue(r.SequenceEqual(rv.Reverse()))

        Dim r3 = New Range(-24, 15, 7)

        Assert.IsTrue(r3.SequenceEqual({-24, -17, -10, -3, 4, 11}))
    End Sub

End Class
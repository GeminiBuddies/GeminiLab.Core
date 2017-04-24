Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports GeminiLab.Core.Collections

<TestClass()> Public Class Collection

    <TestMethod()> Public Sub Expand()
        Dim a = {
            New Integer() {1, 2, 3},
            New Integer() {4, 5},
            New Integer() {6}
        }

        Dim expanded = a.Expand()

        Assert.IsTrue({1, 2, 3, 4, 5, 6}.SequenceEqual(expanded))
    End Sub

    <TestMethod> Public Sub ArbitratyIntersectAndUnion()
        Dim a = {
            New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 9},
            New Integer() {2, 3, 5, 7, 11, 13, 17},
            New Integer() {1, 3, 5, 7, 9, 11, 13}
        }

        Dim ArbitraryIntersect = a.ArbitraryIntersect()
        Dim ArbitraryUnion = a.ArbitraryUnion()

        Assert.IsTrue({3, 5, 7}.SequenceEqual(ArbitraryIntersect))
        Assert.IsTrue({1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 13, 17}.SequenceEqual(ArbitraryUnion))
    End Sub

    <TestMethod> Public Sub NullParamCheck()
        Dim null = TryCast(Nothing, IEnumerable(Of String))
        Dim Catched As Boolean

        Try
            Catched = False
            null.ArbitraryIntersect().EnumerateAll()
        Catch ex As ArgumentNullException : Catched = True
        Finally : If Not Catched Then Assert.Fail()
        End Try

        Try
            Catched = False
            null.ArbitraryUnion().EnumerateAll()
        Catch ex As ArgumentNullException : Catched = True
        Finally : If Not Catched Then Assert.Fail()
        End Try

        Try
            Catched = False
            null.Expand().EnumerateAll()
        Catch ex As ArgumentNullException : Catched = True
        Finally : If Not Catched Then Assert.Fail()
        End Try
    End Sub

    <TestMethod> Public Sub Reverse()
        Const TestLength = 256

        Dim slist As New List(Of String)(TestLength)
        Dim ilist As New List(Of Integer)(TestLength)
        Dim ran As New Random()

        Dim dic As New Dictionary(Of Integer, String)

        For i As Integer = 1 To TestLength
            Dim str As String, val As Integer

            Do
                Dim times = ran.Next(1, 10), sb As New StringBuilder

                For j As Integer = 1 To times
                    sb.Append("1234567890qwertyuiopasdfghjklzxcvbnm"(ran.Next(0, 35)))
                Next

                str = sb.ToString()
            Loop While slist.Contains(str)

            Do
                val = ran.Next()
            Loop While ilist.Contains(val)

            slist.Add(str)
            ilist.Add(val)

            dic.Add(val, str)
        Next

        Dim rdic = dic.Reverse()

        For i As Integer = 0 To TestLength - 1
            Assert.AreEqual(rdic(slist(i)), ilist(i))
        Next
    End Sub

End Class
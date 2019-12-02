Public Class Game
    Private ReadOnly _rolls As Integer() = New Integer(21) {}
    Private currentRoll As Integer

    Public Sub Roll(ByVal pins As Integer)
        currentRoll += 1
        _rolls(currentRoll) = pins
    End Sub

    Public ReadOnly Property Score() As Integer
        Get
            Dim theScore As Integer = 0
            Dim frameIndex As Integer = 1
            For frame As Integer = 1 To 10
                If isStrike(frameIndex) Then
                    theScore += 10 + strikeBonus(frameIndex)
                    frameIndex += 1
                ElseIf isSpare(frameIndex) Then
                    theScore += 10 + spareBonus(frameIndex)
                    frameIndex += 2
                Else
                    theScore += sumOfBallsInFrame(frameIndex)
                    frameIndex += 2
                End If
            Next
            Return theScore
        End Get
    End Property

    Private Function isStrike(ByVal frameIndex As Integer) As Boolean
        Return _rolls(frameIndex) = 10
    End Function

    Private Function sumOfBallsInFrame(ByVal frameIndex As Integer) As Integer
        Return _rolls(frameIndex) + _rolls(frameIndex + 1)
    End Function

    Private Function spareBonus(ByVal frameIndex As Integer) As Integer
        Return _rolls(frameIndex + 2)
    End Function

    Private Function strikeBonus(ByVal frameIndex As Integer) As Integer
        Return _rolls(frameIndex + 1) + _rolls(frameIndex + 2)
    End Function

    Private Function isSpare(ByVal frameIndex As Integer) As Boolean
        Return _rolls(frameIndex) + _rolls(frameIndex + 1) = 10
    End Function

End Class


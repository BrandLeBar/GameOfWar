Public Class WarForm

    Private Sub WarForm_Click(sender As Object, e As EventArgs) Handles Me.Click
        Dim theDec As New Deck
        Dim g As Graphics = Me.CreateGraphics


        'g.DrawImage(, 10, 10)
        g.DrawImage(theDeck.DealCard.frontImage, 100, 100)
        'g.DrawImage(two$.frontImage, 150, 150)

        g.Dispose()
    End Sub
End Class

Public Class Deck

    Private _deck As New Stack(Of Card)

    Sub test()
        Dim ah As New Card("a", "h")
        Dim asc As New Card("a", "c")
        Dim ad As New Card("a", "d")
        Dim asp As New Card("a", "s")
        Me._deck.Push(ah)
        Me._deck.Push(asc)
        Me._deck.Push(ad)
        Me._deck.Push(asp)
    End Sub

    Sub Shuffle()

    End Sub


    ''' <summary>
    ''' Deals one card from off the top of the deck
    ''' </summary>
    ''' <returns>Card</returns>
    Function DealCard() As Card
        Return _deck.Pop
    End Function

    ''' <summary>
    ''' Returns the number of cards remaining in the deck
    ''' </summary>
    ''' <returns>Integer</returns>
    Function CardsRemaining() As Integer
        Return _deck.Count
    End Function

    Sub New()
        test()
    End Sub

End Class

Public Class Card

    Private _suit As String
    Public Property suit() As String
        Get
            Return _suit
        End Get
        Set(ByVal value As String)
            _suit = value
        End Set
    End Property

End Class


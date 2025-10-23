Public Class WarForm
    Dim theDeck As New Deck

    Private Sub WarForm_Click(sender As Object, e As EventArgs) Handles Me.Click

        Dim g As Graphics = Me.CreateGraphics


        'g.DrawImage(, 10, 10)
        Try
            g.DrawImage(theDeck.DealCard.frontImage, 100, 100)
        Catch ex As Exception
            'nothing
        End Try

        'g.DrawImage(two$.frontImage, 150, 150)
        Me.Text = theDeck.CardsRemaining

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
        Dim _suit$, _rank$

        For suit = 1 To 4
            For rank = 1 To 13

                Select Case suit
                    Case 1
                        _suit = "s"
                    Case 2
                        _suit = "h"
                    Case 3
                        _suit = "c"
                    Case 4
                        _suit = "d"
                End Select

                Select Case rank
                    Case 1
                        _rank = "a"
                    Case 2 To 10
                        _rank = rank.ToString
                    Case 11
                        _rank = "j"
                    Case 12
                        _rank = "q"
                    Case 13
                        _rank = "k"
                End Select

                Dim newCard As New Card(_rank, _suit)
                Me._deck.Push(newCard)

            Next
        Next


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
        'test()
        Shuffle()
    End Sub

End Class

Public Class Card

    Sub New(rank As String, suit As String)

        Me.suit = suit.ToUpper
        Me.rank = rank.ToUpper
        Me.frontImage = My.Resources.ResourceManager.GetObject($"{Me.rank}{Me.suit}")
        If Me.frontImage Is Nothing Then
            Me.frontImage = My.Resources.ResourceManager.GetObject($"_{Me.rank}{Me.suit}")
        End If
        If Me.frontImage Is Nothing Then
            Me.frontImage = My.Resources.aces
        End If

        Me.backImage = My.Resources.CardBack
    End Sub

    Private _suit, _rank As String
    Public Property suit() As String
        Get
            Return _suit
        End Get
        Set(ByVal value As String)
            _suit = value
        End Set
    End Property

    Public Property rank() As String
        Get
            Return _rank
        End Get
        Set(value As String)
            _rank = value
        End Set
    End Property

    Private _frontImage As Image
    Public Property frontImage() As Image
        Get
            Return _frontImage
        End Get
        Set(ByVal value As Image)
            _frontImage = value
        End Set
    End Property

    Private _backImage As Image
    Public Property backImage() As Image
        Get
            Return _backImage
        End Get
        Set(ByVal value As Image)
            _backImage = value
        End Set
    End Property

End Class


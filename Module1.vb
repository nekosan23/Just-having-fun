Imports System.Console

Module Module1

    'When use please clear after changing sub to prevent loop
    Public FailSafeInteger As Integer = 0

    Public TextVar(2) As String
    Public HelpTextVar(5) As String
    Public GetHardwareInfoTextVar(10) As String
    Public SetLanguageTextVar(2) As String
    'the entire number list is in Text.txt

    Sub Main()
        'Setting windows title (below should do this : just having fun V 0.1.0.0)
        Title = "Just having fun V " + My.Application.Info.Version.ToString
        'Loading configuration
        ConfigurationLoader()
    End Sub
    'Reading configuration file if it exist else it should make new configuration and ask the user
    Sub ConfigurationLoader()
        If My.Settings.UsersLanguage = "" AndAlso FailSafeInteger = 1 Then
            WriteLine("Exception thrown FailSafe is Triggered unsaved settings exception")
            ReadLine()
        ElseIf My.Settings.UsersLanguage = "" Then
            Static Dim UserInput As String
            WriteLine("Hello Users it look's like it the first time we meet please enter the language i shall speak in below (for french type fr for english type en) :")
            WriteLine("Bonjours Utilisateur il semble que c'est la première fois qu'on ce rencontre quel language tu veux que je parle en dessous de ce message (Pour Français écris fr et pour anglais en) :")
            UserInput = ReadLine()

            Select Case UserInput
                Case "en"
                    'User asked for english so saving that choice and reloading configurationloader but with a failsafe
                    My.Settings.UsersLanguage = "en"
                    My.Settings.Save()
                    FailSafeInteger = 1
                    Clear()
                    ConfigurationLoader()
                Case "fr"
                    'User asked for french so saving that choice and reloading configurationloader but with a failsafe
                    My.Settings.UsersLanguage = "fr"
                    My.Settings.Save()
                    FailSafeInteger = 1
                    Clear()
                    ConfigurationLoader()
                Case Else
                    Clear()
                    WriteLine("Please retry this option doesn't exist")
                    WriteLine("Merci de réessayez cette option n'existe pas")
                    WriteLine("")
                    WriteLine("Press enter to retry")
                    WriteLine("Veuillez appuyez sur entrez pour réessayez")
                    ReadLine()
                    Clear()
                    ConfigurationLoader()
            End Select
            'User has existing settings so not asking again
        Else
            Clear()
            MainLanguageLoader(My.Settings.UsersLanguage)
        End If
    End Sub

    'Loading all the text into the selected language into string variable **work in progress
    Sub MainLanguageLoader(LanguageSelected As String)
        Select Case LanguageSelected
            Case "en"
                'setting up TextVar
                TextVar(0) = "Welcome to just for fun if you need help just type 'help' to get the whole list of command"
                TextVar(1) = "Loading..."
                TextVar(2) = "This command doesn't exist type help to see all the commands available"
                HelpTextVar(0) = "This is the current list of available programs"
                HelpTextVar(1) = "gethardware ---  Launch GetHardwareInfo() allowing you to see all the hardware info VB can access usefull for developing"
                HelpTextVar(2) = "setlanguage ---  Launch SetLanguage() allowing you to change the main language of the application"
                HelpTextVar(3) = "More coming soon..."
                HelpTextVar(4) = "Press enter to continue..."
                SetLanguageTextVar(0) = "Welcome to SetLanguage"
                SetLanguageTextVar(1) = "What language do you want to select ?"
                SetLanguageTextVar(2) = "This is not a available language"
            Case "fr"
                'setting up TextVar
                TextVar(0) = "bienvenu sur just for fun si tu a besoin d'aide écris 'help' pour avoir la liste de commande"
                TextVar(1) = "Chargement..."
                TextVar(2) = "Cette commande n'existe pas écris help pour voir tout les commandes"
                HelpTextVar(0) = "Ceci est la liste des programmes disponible actuellement"
                HelpTextVar(1) = "gethardwareinfo ---  Lance GetHardwareInfo() ce qui vous permet de voir tout les info matériel que VB peux avoir accès utile pour les développeur"
                HelpTextVar(2) = "setlanguage ---  Lance SetLanguage() ce qui vous permet de changez la langue de l'application"
                HelpTextVar(3) = "Plus a venir..."
                HelpTextVar(4) = "Appuyez sur entré pour continuez..."
                SetLanguageTextVar(0) = "Bienvenu sur SetLanguage"
                SetLanguageTextVar(1) = "Quel language veux tu sélectionnez ?"
                SetLanguageTextVar(2) = "Cette langue n'est pas disponible"
        End Select
        Clear()
        ConsoleHome()
    End Sub

    'This is just the console homepage it also give all the command a point to return to
    Sub ConsoleHome()
        Static Dim Input
        Clear()
        WriteLine(TextVar(0))
        Input = ReadLine()
        ReadingCommands(Input)
    End Sub

    'Reading the sended command
    Sub ReadingCommands(Commands As String)
        Select Case Commands
            Case "gethardware"
                Clear()
                WriteLine("coming soon..")
                WriteLine("press enter to continue..")
                ReadLine()
                ConsoleHome()
            Case "help"
                Help()
            Case "setlanguage"
                Clear()
                SetLanguage()
            Case Else
                WriteLine(TextVar(2))
                System.Threading.Thread.Sleep(400)
                ConsoleHome()
        End Select
    End Sub
    'GetHardwareInfo
    Sub GetHardwareInfo()

    End Sub
    'Help Command
    Sub Help()
        For Each line In HelpTextVar
            WriteLine(line)
        Next
        ReadLine()
        ConsoleHome()
    End Sub
    'SetLanguage
    Sub SetLanguage()
        WriteLine(SetLanguageTextVar(0))
        WriteLine(SetLanguageTextVar(1))
        Static Dim input = ReadLine()
        Select Case input
            Case "en"
                My.Settings.UsersLanguage = "en"
                My.Settings.Save()
            Case "fr"
                My.Settings.UsersLanguage = "fr"
                My.Settings.Save()
            Case Else
                WriteLine(SetLanguageTextVar(2))
                System.Threading.Thread.Sleep(500)
                Clear()
        End Select
        Clear()
        ConfigurationLoader()
    End Sub
End Module
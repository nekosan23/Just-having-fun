Imports System.Console

Module Module1

    'When use please clear after changing sub to prevent loop
    Public FailSafeInteger As Integer = 0

    Public wlc, cmdnf, cmdl, ld As String

    Sub Main()
        'Setting windows title (below should do this : just having fun V 0.1.0.0)
        Title = "Just having fun V " + My.Application.Info.Version.ToString
        'writing down the version number for the updater
        'WritingVersionForUpdate()
        'Loading configuration
        ConfigurationLoader()
    End Sub

    'Writing down the version so the updater know the version and if a update is available and also launching the updater to update
    Sub WritingVersionForUpdate()
        'checking if the version file is existing if so delete to make a new one
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory + "/version.txt") Then
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.CurrentDirectory + "/version.txt")
            WritingVersionForUpdate()
        Else
            My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.CurrentDirectory + "/version.txt", My.Application.Info.Version.Major.ToString + My.Application.Info.Version.Minor.ToString + My.Application.Info.Version.Build.ToString + My.Application.Info.Version.Revision.ToString, True)
        End If
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
                ld = My.Resources.lden
                WriteLine(ld)
                wlc = My.Resources.wlcen
                cmdnf = My.Resources.cmdnfen
                cmdl = My.Resources.cmdlen
            Case "fr"
                ld = My.Resources.ldfr
                WriteLine(ld)
                wlc = My.Resources.wlcfr
                cmdnf = My.Resources.cmdnffr
                cmdl = My.Resources.cmdlfr
        End Select
        Clear()
        ConsoleHome()
    End Sub

    'This is just the console homepage it also give all the command a point to return to
    Sub ConsoleHome()
        Static Dim Input
        Clear()
        WriteLine(wlc)
        Input = ReadLine()
        ReadingCommands(Input)
    End Sub

    'Reading the sended command
    Sub ReadingCommands(Commands As String)
        Select Case Commands
            Case "gethardware"
                WriteLine("coming soon..")
                WriteLine("press enter to continue..")
                ReadLine()
                ConsoleHome()
            Case "help"
                Help()
            Case Else
                WriteLine("Sorry we couldn't find a command called " + Commands)
                ReadLine()
                ConsoleHome()
        End Select
    End Sub
    'GetHardwareInfo
    Sub GetHardwareInfo()

    End Sub
    'Help Command
    Sub Help()
        WriteLine("this is the current list of available programs :")
        WriteLine("gethardware -- start the GetHardwareInfo() allowing you to ask for specific info or just to browse what VB .net can acces")
        WriteLine("more coming soon...")
        WriteLine("press enter to continue..")
        ReadLine()
        ConsoleHome()
    End Sub
End Module
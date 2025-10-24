namespace DapperMsSqlite

open Serilog

type LogType =
    | Console
    | File


[<RequireQualifiedAccess>]
module DpMsSqlLog =


    let loggerFileConfig =
        LoggerConfiguration().MinimumLevel.Debug().WriteTo.File(".\DapperMsSqlite.log").CreateLogger()

    let loggerConsoleConfig =
        LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().CreateLogger()

    let mutable CLog = loggerFileConfig

    let loggerSetup (l: LogType) =
        match l with
        | LogType.Console -> CLog <- loggerConsoleConfig
        | LogType.File -> CLog <- loggerFileConfig

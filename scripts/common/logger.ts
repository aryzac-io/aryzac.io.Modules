enum LogLevel {
  Error = 0,
  Warn = 1,
  Info = 2,
  Debug = 3,
  Trace = 4
}

const logLevel = LogLevel.Trace;

const logger = {
  error: (message: string) => {
      if (logLevel >= LogLevel.Error) {
          console.error(`${new Date()} ERROR: ${message}`);
      }
  },
  warn: (message: string) => {
      if (logLevel >= LogLevel.Warn) {
          console.warn(`${new Date()} WARN: ${message}`);
      }
  },
  info: (message: string) => {
      if (logLevel >= LogLevel.Info) {
          console.log(`${new Date()} INFO: ${message}`);
      }
  },
  debug: (message: string) => {
      if (logLevel >= LogLevel.Debug) {
          console.log(`${new Date()} DEBUG: ${message}`);
      }
  },
  trace: (message: string) => {
      if (logLevel >= LogLevel.Trace) {
          console.log(`${new Date()} TRACE: ${message}`);
      }
  }
};
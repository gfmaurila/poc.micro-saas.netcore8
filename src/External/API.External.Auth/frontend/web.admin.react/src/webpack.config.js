module.exports = {
    entry: {
      app1: './src/App1.js',
      app2: './src/App2.js',
    },
    output: {
      filename: '[name].bundle.js',
      path: __dirname + '/dist',
    },
    // Outras configurações do Webpack aqui
  };
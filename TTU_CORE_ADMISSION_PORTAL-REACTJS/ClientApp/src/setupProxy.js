const createProxyMiddleware = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:38887';

const context =  [
  "/weatherforecast",
  "/api",
  "/applicationform",
    "/Ama",
    "/selectbox/districts",
    "/SelectBox",
  "/SelectBox/Programmes",
  "/selectbox/programme",
  "/applicationform/SaveForm",
    "/applicationform/finalize",
    "/finalize",
  "/_configuration",
  "/.well-known",
  "/Identity",
  "/connect",
  "/ApplyDatabaseMigrations",
  "/_framework"
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false
  });

  app.use(appProxy);
};

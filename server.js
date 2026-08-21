const express = require('express');
const path = require('path');

const parseNumberMiddleware = require('./middlewares/parseNumberMiddleware');
const signMiddleware = require('./middlewares/signMiddleware');
const thousandsMiddleware = require('./middlewares/thousandsMiddleware');
const hundredsMiddleware = require('./middlewares/hundredsMiddleware');
const tensUnitsMiddleware = require('./middlewares/tensUnitsMiddleware');
const finalizeMiddleware = require('./middlewares/finalizeMiddleware');

const app = express();
const PORT = process.env.PORT || 3000;

app.use(express.static(path.join(__dirname, 'public')));

app.get(
  '/interpret',
  parseNumberMiddleware,
  signMiddleware,
  thousandsMiddleware,
  hundredsMiddleware,
  tensUnitsMiddleware,
  finalizeMiddleware
);

app.listen(PORT, () => {
  console.log(`Сервер запущено: http://localhost:${PORT}`);
});

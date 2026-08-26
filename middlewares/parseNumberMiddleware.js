function parseNumberMiddleware(req, res, next) {
  const raw = req.query.number;

  if (raw === undefined || raw === '') {
    return res.status(400).json({ error: 'Параметр "number" є обов\'язковим' });
  }

  const number = Number(raw);

  if (!Number.isInteger(number)) {
    return res.status(400).json({ error: 'Параметр "number" має бути цілим числом' });
  }

  if (number < -100000 || number > 100000) {
    return res.status(400).json({ error: 'Число має бути в діапазоні від -100000 до 100000' });
  }

  req.originalNumber = number;
  req.num = Math.abs(number);
  req.words = [];

  next();
}

module.exports = parseNumberMiddleware;

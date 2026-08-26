function signMiddleware(req, res, next) {
  if (req.originalNumber < 0) {
    req.words.push('мінус');
  }
  next();
}

module.exports = signMiddleware;

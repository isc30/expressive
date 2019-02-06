# THIS IS A WORK IN PROGRESS. I'M ALSO WRITING ARTICLES ABOUT IT

# Expressive
Finslly a fully fledged utility library to deal with expressions

# Roadmap

LinqKit:
- [x] Shortcut expression/function builder methods (`Expr.New`/`Func.New`)
- [x] Invoke/Expand (`call`/`inline` in expressive)
- [ ] IQueryable provider
- [ ] Query interceptor
- [ ] Predicate helper
- [ ] ExpressionVisitor base class

Extras:
- [ ] Call with constants (think proper syntax)
- [ ] Optimize Call/ToFunc to simple call stack and avoid compiling the same expression multiple times
- [ ] Expression.Compile() with DebugInfoGenerator
- [ ] ConstExpr optimizer
- [ ] Helper functions (member path extractor?)
- [ ] Static method replacer (replace the call with logic) (https://blog.staticvoid.co.nz/2016/composable_repositories_-_nesting_extensions/)
- [ ] Functional Monads
- [ ] Functional Try/Catch
- [ ] Date/DateRange functions
- [ ] Variables in IQueryable

Linq To Expressions:
- [ ] Tree functions for `Expression` (descendants, children, etc)
- [ ] Tree query builder

Security:
- [ ] Security Restrictions

SQL:

- [ ] Expression to SQL view / function

Extras:
- [ ] ToTraceString

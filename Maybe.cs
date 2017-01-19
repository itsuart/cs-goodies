    public struct Maybe<T> {
        public readonly static Maybe<T> Nothing = new Maybe<T>(false,default(T));
        private T _value;
        public readonly bool HasValue;

        private Maybe(bool hasValue, T value) {
            HasValue = hasValue;
            _value = value;
        }

        public T Value {
            get {
                if (!HasValue) throw new InvalidOperationException();
                return _value;
            }
            private set { _value = value; }
        }

        public Maybe<TResult> Bind<TResult>(Func<T, Maybe<TResult>> f) {
            return Match(f, () => Maybe<TResult>.Nothing);
        }

        public static Maybe<T> Just(T value) { return new Maybe<T>(true, value); }

        public TResult Match<TResult>(Func<T, TResult> justMatcher, Func<TResult> nothingMatcher) {
            return HasValue ? justMatcher(Value) : nothingMatcher();
        }

        public override bool Equals(object other){
            if (base.Equals(other)) return true;
            if (! (other is Maybe<T>)) return false;
            var otherMaybe = (Maybe<T>)other;

            if (HasValue != otherMaybe.HasValue){
                return false;
            }

            if (HasValue == false && otherMaybe.HasValue == false){
                return true;
            }

            return Value.Equals(otherMaybe.Value);
        }
    }

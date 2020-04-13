namespace Bench
{
    public static class Queries
    {
        public const string ThreeFields = @"
            {
                hero(episode: EMPIRE) {
                    id
                    name
                }
            }";

        public const string SmallQuery = @"
            {
                hero(episode: EMPIRE) {
                    id
                    name
                    appearsIn
                    friends {
                        id
                        name
                        appearsIn
                        height
                        ... on Droid {
                            primaryFunction
                        }
                        ... on Human {
                            homePlanet
                        }
                    }
                }
            }";

        public const string MediumQuery = @"
            {
                newhope: hero(episode: NEW_HOPE) {
                    id
                    name
                    appearsIn
                    friends {
                        id
                        name
                        appearsIn
                        height
                        ... on Droid {
                            primaryFunction
                        }
                        ... on Human {
                            homePlanet
                        }
                    }
                }
                empire: hero(episode: EMPIRE) {
                    id
                    name
                    appearsIn
                    friends {
                        id
                        name
                        appearsIn
                        height
                        ... on Droid {
                            primaryFunction
                        }
                        ... on Human {
                            homePlanet
                        }
                    }
                }
                jedi: hero(episode: JEDI) {
                    id
                    name
                    appearsIn
                    friends {
                        id
                        name
                        appearsIn
                        height
                        ... on Droid {
                            primaryFunction
                        }
                        ... on Human {
                            homePlanet
                        }
                    }
                }
            }";

        public const string MediumPlusIntrospection = @"
            {
                newhope: hero(episode: NEW_HOPE) {
                    id
                    name
                    appearsIn
                    friends {
                        id
                        name
                        appearsIn
                        height
                        ... on Droid {
                            primaryFunction
                        }
                        ... on Human {
                            homePlanet
                        }
                    }
                }
                empire: hero(episode: EMPIRE) {
                    id
                    name
                    appearsIn
                    friends {
                        id
                        name
                        appearsIn
                        height
                        ... on Droid {
                            primaryFunction
                        }
                        ... on Human {
                            homePlanet
                        }
                    }
                }
                jedi: hero(episode: JEDI) {
                    id
                    name
                    appearsIn
                    friends {
                        id
                        name
                        appearsIn
                        height
                        ... on Droid {
                            primaryFunction
                        }
                        ... on Human {
                            homePlanet
                        }
                    }
                }
                __schema {
                    queryType { name }
                    mutationType { name }
                    subscriptionType { name }
                    types {
                        ...FullType
                    }
                    directives {
                        name
                        description
                        args {
                            ...InputValue
                        }
                        onOperation
                        onFragment
                        onField
                    }
                }
            }

            fragment FullType on __Type {
                kind
                name
                description
                fields(includeDeprecated: true) {
                    name
                    description
                    args {
                        ...InputValue
                    }
                    type {
                        ...TypeRef
                    }
                    isDeprecated
                    deprecationReason
                }
                inputFields {
                ...InputValue
                }
                interfaces {
                    ...TypeRef
                }
                enumValues(includeDeprecated: true) {
                    name
                    description
                    isDeprecated
                    deprecationReason
                }
                possibleTypes {
                    ...TypeRef
                }
            }

            fragment InputValue on __InputValue {
                name
                description
                type { ...TypeRef }
                defaultValue
            }

            fragment TypeRef on __Type {
                kind
                name
                ofType {
                    kind
                    name
                    ofType {
                        kind
                        name
                        ofType {
                            kind
                            name
                        }
                    }
                }
            }
            ";

        public const string Introspection = @"
            query IntrospectionQuery {
                __schema {
                    queryType { name }
                    mutationType { name }
                    subscriptionType { name }
                    types {
                        ...FullType
                    }
                    directives {
                        name
                        description
                        args {
                            ...InputValue
                        }
                        onOperation
                        onFragment
                        onField
                    }
                }
            }

            fragment FullType on __Type {
                kind
                name
                description
                fields(includeDeprecated: true) {
                    name
                    description
                    args {
                        ...InputValue
                    }
                    type {
                        ...TypeRef
                    }
                    isDeprecated
                    deprecationReason
                }
                inputFields {
                ...InputValue
                }
                interfaces {
                    ...TypeRef
                }
                enumValues(includeDeprecated: true) {
                    name
                    description
                    isDeprecated
                    deprecationReason
                }
                possibleTypes {
                    ...TypeRef
                }
            }

            fragment InputValue on __InputValue {
                name
                description
                type { ...TypeRef }
                defaultValue
            }

            fragment TypeRef on __Type {
                kind
                name
                ofType {
                    kind
                    name
                    ofType {
                        kind
                        name
                        ofType {
                            kind
                            name
                        }
                    }
                }
            }
        ";
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Bench.Data;
using Benchmark.src.GraphQLDotNet;
using BenchmarkDotNet.Attributes;
using GraphQL;
using GraphQL.Server.Internal;
using HotChocolate.Execution;

namespace Bench
{
    [RPlotExporter, CategoriesColumn, RankColumn, MeanColumn, MedianColumn, MemoryDiagnoser]
    public class ExecutorBenchmarks
    {
        private readonly IServiceProvider _services;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IGraphQLExecuter<BenchSchema> _gqlDotNetExecutor;

        public ExecutorBenchmarks()
        {
            _services = new ServiceCollection()
                .AddSingleton<CharacterRepository>()
                .AddSingleton<ReviewRepository>()
                .BuildServiceProvider();

            _queryExecutor = HotChocolate.Setup.Create();
            _gqlDotNetExecutor = GraphQLDotNet.Setup.Create();
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_SmallQuery()
        {
            var request = QueryRequestBuilder.New()
                .SetQuery(@"
                {
                    hero(episode: EMPIRE) {
                        id
                        name
                    }
                }
                ")
                .SetServices(_services)
                .Create();

            return await _queryExecutor.ExecuteAsync(request);
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_SmallQuery_With_Fragments()
        {
            var request = QueryRequestBuilder.New()
                .SetQuery(@"
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
                }
                ")
                .SetServices(_services)
                .Create();

            return await _queryExecutor.ExecuteAsync(request);
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_SmallQuery_Introspection()
        {
            var request = QueryRequestBuilder.New()
                .SetQuery(@"
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

                ")
                .SetServices(_services)
                .Create();

            return await _queryExecutor.ExecuteAsync(request);
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_SmallQuery()
        {
            return await _gqlDotNetExecutor.ExecuteAsync("",
                @"
                {
                    hero(episode: EMPIRE) {
                        id
                        name
                    }
                }
                ", null, null);
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_SmallQuery_With_Fragments()
        {
            return await _gqlDotNetExecutor.ExecuteAsync("",
                @"
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
                }
                ", null, null);
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_SmallQuery_Introspection()
        {
            return await _gqlDotNetExecutor.ExecuteAsync("",
                @"
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
                ", null, null);
        }
    }
}
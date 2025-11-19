const path = require('path');

module.exports = {
    mode: 'production',
    entry: {
        app: ['babel-polyfill', './client/src/index.js']
    },
    output: {
        path: path.resolve(__dirname, '../client/build'), // string
        filename: '[name].js',
        publicPath: '/products/maint/build/'
    },
    module: {
        rules: [
            {
                exclude: [/\.html$/, /\.(js|jsx)$/, /\.css$/, /\.scss$/, /\.json$/, /\.svg$/],
                use: {
                    loader: 'url-loader',
                    query: {
                        limit: 10000,
                        name: 'media/[name].[hash:8].[ext]'
                    }
                }
            },
            {
                test: /\.js$/,
                exclude: /(node_modules)/,
                use: {
                    loader: 'babel-loader'
                }
            },
            {
                test: /\.css$/,
                use: [
                    'style-loader',
                    {
                        loader: 'css-loader',
                        options: {
                            importLoaders: 1
                        }
                    },
                    'postcss-loader'
                ]
            },
            {
                test: /\.scss$/,
                use: [
                    'style-loader',
                    {
                        loader: 'css-loader',
                        options: {
                            importLoaders: 1
                        }
                    },
                    'sass-loader',
                    'postcss-loader'
                ]
            },
            {
                test: /\.svg$/,
                use: {
                    loader: 'file-loader',
                    query: {
                        name: 'media/[name].[hash:8].[ext]'
                    }
                }
            }
        ]
    },
    resolve: {
        alias: {
            react: path.resolve('./node_modules/react'),
            'react-dom': path.resolve('./node_modules/react-dom'),
            'react-redux': path.resolve('./node_modules/react-redux'),
            notistack: path.resolve('./node_modules/notistack')
        },
        modules: [path.resolve('node_modules'), 'node_modules'].concat(/* ... */)
    },
    devtool: 'cheap-source-map' // enum
    // enhance debugging by adding meta info for the browser devtools
};

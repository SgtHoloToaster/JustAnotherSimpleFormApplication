const path = require('path');
const entryPointFile = 'ClientApp/main.js';
const outputFolder = 'wwwroot/dist';

const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = {
    mode: 'development',
    entry: { main: path.resolve(__dirname, entryPointFile) },
    resolve: { alias: { vue: 'vue/dist/vue.esm.js' } },
    output: {
        path: path.resolve(__dirname, outputFolder),
        filename: 'main-bundle.js',
        publicPath: 'dist/'
    },
    module: {
        rules: [
            {
                enforce: 'pre',
                test: /\.js$/,
                exclude: /node_modules/,
                use: 'eslint-loader'
            },
            {
                test: /\.vue$/,
                exclude: /node_modules/,
                use: 'vue-loader'
            },
            {
                test: /\.css$/,
                use: [
                    { loader: 'style-loader' },
                    { loader: 'css-loader' }
                ]
            },
            {
                test: /\.(eot|woff|woff2|ttf|svg|png|jpe?g|gif)(\?\S*)?$/,
                use: 'url-loader?limit=100000&name=[name].[ext]'
            }
        ]
    },
    plugins: [
        new VueLoaderPlugin()
    ]
};
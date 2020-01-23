const path = require('path');
const entryPointFile = 'ClientApp/main.js';
const outputFolder = 'wwwroot/dist';

const VueLoaderPlugin = require('vue-loader/lib/plugin');
const TerserPlugin = require('terser-webpack-plugin');
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");

module.exports = (_, options) => {
    return {
        mode: options ? options.mode : 'development',
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
                }
            ]
        },
        optimization: {
            minimizer: [
                new TerserPlugin(),
                new OptimizeCSSAssetsPlugin({})
            ]
        },
        plugins: [
            new VueLoaderPlugin()
        ]
    };
};
/* eslint-disable */
const path = require('path');
const webpack = require('webpack');
const MODULE_BUILD_DIR = path.resolve(__dirname, './wwwroot/dist/assets/development');
const MODULE_APP_JS_DIR = path.resolve(__dirname, './wwwroot/js/');
const WebpackMd5Hash = require("webpack-md5-hash");
const globImporter = require('node-sass-glob-importer');
const workboxPlugin = require('workbox-webpack-plugin');
const WriteFilePlugin = require('write-file-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
// const dServer =  require('webpack-dev-server');

process.env.NODE_ENV = "development";

const config = {
    mode: "development",
	target: "web",
	devtool: "cheap-module-source-map", // enable devtool for better debugging experience
	context: __dirname, // string (absolute path!)
	entry: [
		'@babel/polyfill',
		'font-awesome/scss/font-awesome.scss',
		'./wwwroot/js/main.js',
	],
	output: {
		path: MODULE_BUILD_DIR,
		filename: '[name].bundle.js',
		chunkFilename: '[id].chunk.js',
	},
	optimization: {
    splitChunks: {
      chunks: 'all',
		},
	},
	module: {
		noParse: /node_modules\/quill\/dist/,
		rules: [
				{
					test: /\.(js|jsx)$/,
					enforce: "pre",
					loader: "eslint-loader",
					exclude: /node_modules/,
					options: {
						emitWarning: true,
						configFile: "./.eslintrc.js"
					}
			  	},
				{
					test: /\.(js|jsx)$/,
					exclude: /node_modules/, // exclude the node_module directory
					loader: 'babel-loader' // use this (babel-code) loader'
				},
				{
					test: /\.s[c|a]ss$/,
					use: [
						{
							loader: 'style-loader',
						},
						{ 
							loader: 'css-loader', 
							options: { 
								sourceMap: true,
								importLoaders: 3,
							} 
						},
						{
							loader: 'postcss-loader',
							options: {
								ident: 'postcss',
								sourceMap: true,
								plugins: () => [
									require('precss'),
                                    require("cssnano"),
									require('autoprefixer')({
                                        grid: true,
                                        remove: true,
									}),
									require('postcss-flexbugs-fixes'),
								]
							}
						},
						{
							loader: 'sass-loader',
							options: {
								sourceMap: true,
								sassOptions: {
									importer: globImporter()
								}
							}
						}
					]
				},
				{
					test: /\.css$/,
					use: ['style-loader', 'css-loader']
				},
				// the file-loader will copy the file and fix the appropriate url
				{
					test: /\.(ttf|eot|svg|woff(2)?)(\?v=[0-9]\.[0-9]\.[0-9])?$/,
					loader: "file-loader",
					options: {
                        mimetype: 'application/font-woff',
                        name: '[name].[ext]',
                        publicPath: 'https://localhost:9099/',
                        postTransformPublicPath: (p) => `__webpack_public_path__ + ${p}`,
                    }
				},
				// font-awesome
				{
					test: /font-awesome\.config\.js/,
					use: [
						{ loader: 'style-loader' },
						{ loader: 'font-awesome-loader' }
					]
				},
				{
					test: /\.(jpe?g|png|gif|svg)$/i,
					use: [
						'file-loader?name=images/[name].[ext]',
						'image-webpack-loader?bypassOnDebug',
					]
				}
		],
	},
	resolve: {
		modules: [
			'node_modules',
			path.resolve(MODULE_APP_JS_DIR), //__dirname, 'wwwroot/Scripts'
		],
		extensions: ['.js', '.json', '.jsx', '.css'],
	},
	node: {
		fs: 'empty'
	},
	plugins: [
		new CleanWebpackPlugin(),
		new webpack.ProvidePlugin({
			$: "jquery",
			jQuery: "jquery",
			fs: "fs"
		}),
		new WebpackMd5Hash(),
		new workboxPlugin.GenerateSW({
			swDest: 'sw.js',
			clientsClaim: true,
			skipWaiting: true,
		}),
        // new WriteFilePlugin({
		// 	// Write only files that have ".js" extension.
		// 	test: /\.js$/,
		// }),
		new WriteFilePlugin(),
	],
	// webpack-dev-server config
	devServer: {
		contentBase: path.resolve(__dirname, './'), // a directory or url to serve HTML content from
		historyApiFallback: false, // fallback to /index.html for Single Page Applications
		inline: true, // inline mode (set to false to disable including client scripts (like livereload))
		open: false, // open default browser while lanching
		port: 9099,
        hot: true, // hot reload
        https: true,
	},
};

module.exports = config;

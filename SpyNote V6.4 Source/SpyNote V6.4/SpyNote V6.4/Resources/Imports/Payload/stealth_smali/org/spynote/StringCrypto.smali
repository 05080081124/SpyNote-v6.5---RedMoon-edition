.class public Lorg/spynote/StringCrypto;
.super Ljava/lang/Object;
.source "StringCrypto.java"


# XOR key — overwritten at build time (16 bytes)
.field private static final K:[B


.method static constructor <clinit>()V
    .locals 1
    const/16 v0, 0x10
    new-array v0, v0, [B
    fill-array-data v0, :key_data
    sput-object v0, Lorg/spynote/StringCrypto;->K:[B
    return-void

    :key_data
    .array-data 1
        0x5a
        0x3c
        0x9f
        0x12
        0x88
        0x44
        0xde
        0x71
        0x2b
        0x6e
        0x01
        0xf3
        0x55
        0xaa
        0x39
        0xcc
    .end array-data
.end method


.method public static d([B)Ljava/lang/String;
    .locals 6

    if-nez p0, :ok
    const-string v0, ""
    return-object v0

    :ok
    :try_start_0
    sget-object v0, Lorg/spynote/StringCrypto;->K:[B
    array-length v1, p0
    new-array v2, v1, [B
    const/4 v3, 0x0

    :loop
    if-ge v3, v1, :done
    aget-byte v4, p0, v3
    array-length v5, v0
    rem-int v5, v3, v5
    aget-byte v5, v0, v5
    xor-int/2addr v4, v5
    int-to-byte v4, v4
    aput-byte v4, v2, v3
    add-int/lit8 v3, v3, 0x1
    goto :loop

    :done
    new-instance v0, Ljava/lang/String;
    const-string v1, "UTF-8"
    invoke-direct {v0, v2, v1}, Ljava/lang/String;-><init>([BLjava/lang/String;)V
    return-object v0
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    const-string v0, ""
    return-object v0
.end method
